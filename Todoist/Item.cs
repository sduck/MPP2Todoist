// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//    Defines the Item type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Newtonsoft.Json.Linq;

namespace MPP2Todoist.Todoist
{
    /// <summary>
    /// Todoist.com task (or "item" as it is referred to in the API).
    /// </summary>
    public class Item
    {
        #region Constants and Fields

        /// <summary>
        /// Task text.
        /// </summary>
        private readonly string _content;

        /// <summary>
        /// The raw string of the due date.
        /// </summary>
        private readonly string _dateString;

        /// <summary>
        /// The next due date.
        /// </summary>
        private readonly string _dueDate;

        /// <summary>
        /// Task's unique id.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Task's indent level.
        /// </summary>
        private readonly int _indent;

        /// <summary>
        /// True if the task has been 'checked' on the website, which usually means it has been completed.
        /// </summary>
        private readonly bool _isChecked;

        /// <summary>
        /// True if the task has been put in the history, which usually means it has been completed.
        /// </summary>
        private readonly bool _isInHistory;

        /// <summary>
        /// Are the subtasks collapsed.
        /// </summary>
        private readonly bool _isSubTasksCollapsed;

        /// <summary>
        /// Task's weight in the order of tasks.
        /// </summary>
        private readonly int _itemOrder;

        /// <summary>
        /// The JSON data of the task.
        /// </summary>
        private readonly string _jsonData;

        /// <summary>
        /// The id of the user who owns the task.
        /// </summary>
        private readonly int _ownerId;

        /// <summary>
        /// The priority of the task.
        /// </summary>
        private readonly int _priority;

        /// <summary>
        /// The id of the project the task belongs to.
        /// </summary>
        private readonly int _projectId;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class. 
        /// </summary>
        /// <param name="jsonData">
        /// A task's JSON data.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="jsonData"/> is null.
        /// </exception>
        public Item(string jsonData)
        {
            JObject o = JObject.Parse(jsonData);

            if (o.First == null)
            {
                throw new ArgumentNullException(jsonData);
            }

            _id = (int)o.SelectToken("id");
            _ownerId = (int)o.SelectToken("user_id");
            _isSubTasksCollapsed = Convert.ToBoolean((int)o.SelectToken("collapsed"));
            _isInHistory = Convert.ToBoolean((int)o.SelectToken("in_history"));
            _priority = (int)o.SelectToken("priority");
            _itemOrder = (int)o.SelectToken("item_order");
            _content = (string)o.SelectToken("content");
            _indent = (int)o.SelectToken("indent");
            _projectId = (int)o.SelectToken("project_id");
            _isChecked = Convert.ToBoolean((int)o.SelectToken("checked"));
            _dateString = (string)o.SelectToken("date_string");
            _dueDate = (string)o.SelectToken("due_date");
            _jsonData = jsonData;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the text of the task.
        /// </summary>
        public string Content
        {
            get
            {
                return _content;
            }
        }

        /// <summary>  
        /// Gets the raw string of the due date.
        /// </summary>
        public string DateString
        {
            get
            {
                return _dateString;
            }
        }

        /// <summary>
        /// Gets the next due date.
        /// </summary>
        public string DueDate
        {
            get
            {
                return _dueDate;
            }
        }

        /// <summary>
        /// Gets the unique id of the task.
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Gets the indent level of the task.
        /// </summary>
        public int Indent
        {
            get
            {
                return _indent;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the task is checked (is completed) or not.
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the task is in the history (is completed) or not.
        /// </summary>
        public bool IsInHistory
        {
            get
            {
                return _isInHistory;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the subtasks are collapsed or not.
        /// </summary>
        public bool IsSubtasksCollapsed
        {
            get
            {
                return _isSubTasksCollapsed;
            }
        }

        /// <summary>
        /// Gets the task weight in the order of tasks.
        /// </summary>
        public int ItemOrder
        {
            get
            {
                return _itemOrder;
            }
        }

        /// <summary>
        /// Gets a string of JSON data.
        /// </summary>
        public string JsonData
        {
            get
            {
                return _jsonData;
            }
        }

        /// <summary>
        /// Gets the id of the user who owns the task.
        /// </summary>
        public int OwnerId
        {
            get
            {
                return _ownerId;
            }
        }

        /// <summary>
        /// Gets the task priority.
        /// </summary>
        public int Priority
        {
            get
            {
                return _priority;
            }
        }

        /// <summary>
        /// Gets the id of the project the task belongs to.
        /// </summary>
        public int ProjectId
        {
            get
            {
                return _projectId;
            }
        }

        #endregion
    }
}