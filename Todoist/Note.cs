// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Note.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the Note type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json.Linq;

namespace MPP2Todoist.Todoist
{
    /// <summary>
    /// Todoist.com Note type.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Note content.
        /// </summary>
        private readonly string _content;

        /// <summary>
        /// Unique note id.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Id of the item the note belongs to.
        /// </summary>
        private readonly int _itemId;

        /// <summary>
        /// The JSON data for the note.
        /// </summary>
        private readonly string _jsonData;

        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class.
        /// </summary>
        /// <param name="jsonData">
        /// The json data.
        /// </param>
        internal Note(string jsonData)
        {
            JArray o = JArray.Parse(jsonData);

            _id = (int)o.SelectToken("id");
            _itemId = (int)o.SelectToken("item_id");
            _content = (string)o.SelectToken("content");
            _jsonData = jsonData;
        }

        /// <summary>
        /// Gets the id of the note.
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Gets the id of the item the note belongs to.
        /// </summary>
        public int ItemId
        {
            get { return _itemId; }
        }

        /// <summary>
        /// Gets the content/text of the note.
        /// </summary>
        public string Content
        {
            get { return _content; }
        }

        /// <summary>
        /// Gets the JSON data for the note.
        /// </summary>
        public string JsonData
        {
            get { return _jsonData; }
        }
    }
}