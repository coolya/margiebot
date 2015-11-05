using System.Collections.Generic;
using Newtonsoft.Json;

namespace MargieBot.Models
{
    public class SlackAttachment
    {
        [JsonProperty(PropertyName = "color")]
        public string ColorHex { get; set; }

        [JsonProperty(PropertyName = "fallback")]
        public string Fallback { get; set; }

        [JsonProperty(PropertyName = "fields")]
        public IList<SlackAttachmentField> Fields { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "pretext")]
        public string PreText { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "title_link")]
        public string TitleLink { get; set; }

        [JsonProperty(PropertyName = "author_name")]
        public string AuthorName{ get; set; }

        [JsonProperty(PropertyName = "author_link")]
        public string AuthorLink { get; set; }

        [JsonProperty(PropertyName = "author_icon")]
        public string AuthorIcon { get ; set; }

        [JsonProperty(PropertyName = "thumb_url")]
        public string ThumbUrl { get; set; }

        [JsonProperty(PropertyName = "mrkdwn_in")]
        public List<string> MrkdwnIn { get ; set; }

        [JsonIgnore()]
        public bool MarkdownInTitel
        {
            get { return MrkdwnIn.Contains("title"); }
            set
            {
                if (!MarkdownInTitel)
                {
                    this.MrkdwnIn.Add("title");
                }
            }
        }

        [JsonIgnore()]
        public bool MarkdownInPretext
        {
            get { return MrkdwnIn.Contains("pretext"); }
            set
            {
                if (!MarkdownInPretext)
                {
                    this.MrkdwnIn.Add("pretext");
                }
            }
        }

        [JsonIgnore()]
        public bool MarkdownInText
        {
            get { return MrkdwnIn.Contains("text"); }
            set
            {
                if (!MarkdownInText)
                {
                    this.MrkdwnIn.Add("text");
                }
            }
        }


        public SlackAttachment()
        {
            Fields = new List<SlackAttachmentField>();
            MrkdwnIn = new List<string>();
        }
    }
}