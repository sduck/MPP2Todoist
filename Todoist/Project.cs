// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Project.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the Project type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json.Linq;

namespace MPP2Todoist.Todoist
{
    /// <summary>
    /// The project.
    /// </summary>
    public class Project
    {
        #region Constants and Fields

        /// <summary>
        /// The color.
        /// </summary>
        private readonly Color _color;

        /// <summary>
        /// The id.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// The indent.
        /// </summary>
        private readonly int _indent;

        /// <summary>
        /// The is group.
        /// </summary>
        private readonly bool _isGroup;

        /// <summary>
        /// The is sub projects collapsed.
        /// </summary>
        private readonly int _isSubProjectsCollapsed;

        /// <summary>
        /// The item order.
        /// </summary>
        private readonly int _itemOrder;

        /// <summary>
        /// The json data.
        /// </summary>
        private readonly string _jsonData;

        /// <summary>
        /// The name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// The owner id.
        /// </summary>
        private readonly int _ownerId;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class.
        /// </summary>
        /// <param name="jsonData">
        /// The JSON data.
        /// </param>
        internal Project(string jsonData)
        {
            JObject o = JObject.Parse(jsonData);

            _ownerId = (int)o.SelectToken("user_id");
            _name = (string)o.SelectToken("name");
            if (_name[0] == '*')
            {
                _name = _name.Remove(0, 1);
                _isGroup = true;
            }
            else
            {
                _isGroup = false;
            }

            _indent = (int)o.SelectToken("indent");
            _id = (int)o.SelectToken("id");
            _itemOrder = (int)o.SelectToken("item_order");
            _isSubProjectsCollapsed = (int)o.SelectToken("collapsed");

            switch ((string)o.SelectToken("color"))
            {
                case "#bde876":
                    _color = new Color(TodoistColor.Green);
                    break;
                case "#ff8581":
                    _color = new Color(TodoistColor.Red);
                    break;
                case "#ffc472":
                    _color = new Color(TodoistColor.Orange);
                    break;
                case "#faed75":
                    _color = new Color(TodoistColor.Yellow);
                    break;
                case "#a8c9e5":
                    _color = new Color(TodoistColor.Blue);
                    break;
                case "#999999":
                    _color = new Color(TodoistColor.MediumGrey);
                    break;
                case "#e3a8e5":
                    _color = new Color(TodoistColor.Pink);
                    break;
                case "#dddddd":
                    _color = new Color(TodoistColor.LightGrey);
                    break;
                case "#fc603c":
                    _color = new Color(TodoistColor.Flame);
                    break;
                case "#ffcc00":
                    _color = new Color(TodoistColor.Gold);
                    break;
                case "#74e8d4":
                    _color = new Color(TodoistColor.LightOpal);
                    break;
                case "#3cd6fc":
                    _color = new Color(TodoistColor.BrilliantCerulean);
                    break;
            }

            _jsonData = jsonData;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the color-label of the project.
        /// </summary>
        public Color Color
        {
            get
            {
                return _color;
            }
        }

        /// <summary>
        /// Gets the unique project id.
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Gets the indent-level.
        /// </summary>
        public int Indent
        {
            get
            {
                return _indent;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the project is a group or not.
        /// </summary>
        public bool IsGroup
        {
            get
            {
                return _isGroup;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the project is collapsed, hiding subprojects.
        /// </summary>
        public bool IsSubprojectsCollapsed
        {
            get
            {
                return _isSubProjectsCollapsed == 1;
            }
        }

        /// <summary>
        /// Gets the weight in the ordering of the items.
        /// </summary>
        public int ItemOrder
        {
            get
            {
                return _itemOrder;
            }
        }

        /// <summary>
        /// Gets the JSON data of the project.
        /// </summary>
        public string JsonData
        {
            get
            {
                return _jsonData;
            }
        }

        /// <summary>
        /// Gets the name of the project.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Gets the id of the user who owns the project.
        /// </summary>
        public int OwnerId
        {
            get
            {
                return _ownerId;
            }
        }

        #endregion
    }
}