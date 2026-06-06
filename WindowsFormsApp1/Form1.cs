using Humanizer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string authenticationToken = "";
        private static readonly HttpClient client = new HttpClient();
        private static String userID = string.Empty;
        private List<(String, String)> messageIDs = new List<(String, String)>();
        private int delay = 5000;
        private int totalMessages = 0;
        private int totalDMs = 0;
        private int totalServers = 0;

        public Form1()
        {
            InitializeComponent();
            messageContainer.OwnerDraw = true;
            messageContainer.DrawColumnHeader += (s, e) => {
                using (var brush = new LinearGradientBrush(
                    e.Bounds,
                    Color.FromArgb(73, 73, 73),
                    Color.FromArgb(0, 0, 0),
                    LinearGradientMode.Vertical
                ))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }

                using (var format = new StringFormat())
                {
                    format.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(e.Header.Text, e.Font, new SolidBrush(Color.FromArgb(110, 190, 254)), e.Bounds, format);
                }
            };
            messageContainer.DrawItem += (s, e) => e.DrawDefault = true;
            messageContainer.DrawSubItem += (s, e) => e.DrawDefault = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(authenticationToken)) return;
            Console.WriteLine("getting");
            friendsContainer.Enabled = false;
            guildsContainer.Enabled = false;
            try
            {
                errorAuth.Text = "";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("authorization", authenticationToken);
                friendsContainer.Controls.Clear();
                guildsContainer.Controls.Clear();
                button1.Enabled = false;
                var userResponse = await client.GetAsync("https://discord.com/api/v10/users/@me");
                var userString = await userResponse.Content.ReadAsStringAsync();
                var userInfo = JObject.Parse(userString);
                if (userInfo["id"] == null) throw new Exception("Check auth token and try again.");
                userID = userInfo["id"].ToString();
            } catch(Exception exception)
            {
                errorAuth.Text = exception.Message;
                button1.Enabled = true;
                return;
            }

            try
            {
                var response = await client.GetAsync("https://discord.com/api/v10/users/@me/guilds");
                var responseString = await response.Content.ReadAsStringAsync();
                var guilds = JArray.Parse(responseString);
                foreach (var guild in guilds)
                {
                    Label guildName = new Label();
                    guildName.Text = guild["name"].ToString();
                    guildName.Click += (senderLocal, eLocal) => getMessagesGuild(senderLocal, eLocal, guild["id"].ToString(), guild["name"].ToString());
                    guildsContainer.Controls.Add(guildName);
                    serversLabel.Text = $"Servers: {(++totalServers).ToString()}";
                }
            }
            catch (Exception exception) {
                errorAuth.Text = exception.Message;
                button1.Enabled = true;
                return;
            }

            try
            {
                var response = await client.GetAsync("https://discord.com/api/v10/users/@me/relationships");
                var responseString = await response.Content.ReadAsStringAsync();
                var friends = JArray.Parse(responseString);
                foreach (var friend in friends)
                {
                    Label friendName = new Label();
                    if (friend["type"].ToString() != "3") friendName.Text = friend["user"]["username"].ToString();
                    else friendName.Text = friend["name"].ToString();
                    var friendID = friend["id"].ToString();
                    var body = new StringContent(
                        JsonConvert.SerializeObject(new { recipient_id = friendID }),
                        Encoding.UTF8,
                        "application/json"
                    );
                    var channelResponse = await client.PostAsync("https://discord.com/api/v10/users/@me/channels", body);
                    var channelResponseString = await channelResponse.Content.ReadAsStringAsync();
                    var channel = JObject.Parse(channelResponseString);
                    friendName.Click += (senderLocal, eLocal) => getMessagesDM(senderLocal, eLocal, channel["id"].ToString(), friend["user"]["username"].ToString());
                    friendsContainer.Controls.Add(friendName);
                    friendsLabel.Text = $"Friends: {(++totalDMs).ToString()}";
                }
            }
            catch (Exception exception)
            {
                errorAuth.Text = exception.Message;
                button1.Enabled = true;
                return;
            }

            friendsContainer.Enabled = true;
            guildsContainer.Enabled = true;
            button1.Enabled = true;
        }

        private async void getMessagesDM(object sender, EventArgs e, String id, String username)
        {
            button2.Enabled = false;
            messageIDs.Clear();
            messageContainer.Items.Clear();
            label1.Text = "Getting messages... please wait";
            int offsetIncrement = 25;
            int offset = 0;
            int calls = 0;
            totalMessages = 0;
            Console.WriteLine($"GETTING MESSAGES FROM DM");
            guildsContainer.Enabled = false;
            friendsContainer.Enabled = false;
            button1.Enabled = false;
            while (true)
            {
                var responseLabel = await client.GetAsync($"https://discord.com/api/v10/channels/{id}/messages/search?author_id={userID}&sort_by=timestamp&sort_order=desc&offset={offset}");
                calls++;
                var responseStringLabel = await responseLabel.Content.ReadAsStringAsync();
                var messagesJson = JObject.Parse(responseStringLabel);
                var messages = messagesJson["messages"];
                if (messages.ToArray().Length == 0) break;
                foreach (var messageGroup in messages)
                {
                    foreach (var message in messageGroup)
                    {
                        ListViewItem messageContent = new ListViewItem();
                        messageContent.Tag = message["id"].ToString();
                        messageContent.Text = message["author"]["username"].ToString();
                        messageContent.SubItems.Add(message["content"].ToString());
                        messageIDs.Add((message["channel_id"].ToString(), message["id"].ToString()));
                        totalMessages++;
                        messageContainer.Items.Add(messageContent);
                    }
                }
                offset += offsetIncrement;
                await Task.Delay(delay);
            }
            label1.Text = $"Total messages found in DMs with {username}: {totalMessages}";
            if (messageIDs.Count() > 0)
            {
                button2.Enabled = true;
            }
            guildsContainer.Enabled = true;
            friendsContainer.Enabled = true;
            button1.Enabled = true;
            Console.WriteLine($"ENDED {calls} CALLS");
        }

        private async void getMessagesGuild(object sender, EventArgs e, String id, String name)
        {
            button2.Enabled = false;
            messageIDs.Clear();
            messageContainer.Items.Clear();
            label1.Text = "Getting messages... please wait";
            int offsetIncrement = 25;
            int offset = 0;
            int calls = 0;
            totalMessages = 0;
            Console.WriteLine($"GETTING MESSAGES FROM SERVER");
            guildsContainer.Enabled = false;
            friendsContainer.Enabled = false;
            button1.Enabled = false;
            while (true)
            {
                var responseLabel = await client.GetAsync($"https://discord.com/api/v10/guilds/{id}/messages/search?author_id={userID}&sort_by=timestamp&sort_order=desc&offset={offset}");
                calls++;
                var responseStringLabel = await responseLabel.Content.ReadAsStringAsync();
                var messagesJson = JObject.Parse(responseStringLabel);
                var messages = messagesJson["messages"];
                if (messages.ToArray().Length == 0) break;
                foreach (var messageGroup in messages)
                {
                    foreach (var message in messageGroup)
                    {
                        ListViewItem messageContent = new ListViewItem();
                        messageContent.Tag = message["id"].ToString();
                        messageContent.Text = message["author"]["username"].ToString();
                        messageContent.SubItems.Add(message["content"].ToString());
                        messageIDs.Add((message["channel_id"].ToString(), message["id"].ToString()));
                        totalMessages++;
                        messageContainer.Items.Add(messageContent);
                    }
                }
                offset += offsetIncrement;
                await Task.Delay(delay);
            }
            label1.Text = $"Total messages in {name}: {totalMessages}";
            if(messageIDs.Count() > 0)
            {
                button2.Enabled = true;
            }
            guildsContainer.Enabled = true;
            friendsContainer.Enabled = true;
            button1.Enabled = true;
            Console.WriteLine($"ENDED {calls} CALLS");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            authenticationToken = textBox1.Text;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Console.WriteLine("pressed");
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            try {
                sw.Start();
                foreach (var tuple in messageIDs.ToList())
                {
                    var time = TimeSpan.FromMilliseconds(delay * messageIDs.Count()).Humanize();
                    label1.Text = $"Deleting messages... may take {time}";
                    await client.DeleteAsync($"https://discord.com/api/v10/channels/{tuple.Item1}/messages/{tuple.Item2}");
                    var item = messageContainer.Items.Cast<ListViewItem>().FirstOrDefault(i => i.Tag?.ToString() == tuple.Item2);
                    messageIDs.Remove((tuple.Item1, tuple.Item2));
                    messageContainer.Items.Remove(item);
                    if(messageIDs.Count() > 0) await Task.Delay(delay);
                }
                sw.Stop();
            } catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            label1.Text = $"Deleted a total of {totalMessages} messages in {sw.Elapsed.Humanize()}.";
            button2.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://gist.github.com/MarvNC/e601f3603df22f36ebd3102c501116c6");
        }
    }
}
