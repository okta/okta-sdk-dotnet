namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// A question used as a second factor authentication
    /// </summary>
    /// <remarks>
    /// A list can be retrieved by calling <see cref="UserFactorsClient.GetQuestions"/>
    /// </remarks>
    public class Question : ApiObject
    {
        /// <summary>
        /// Gets or sets the type of the question.
        /// </summary>
        /// <value>
        /// A question id like name_of_first_plush_toy, disliked_food, etc.
        /// </value>
        [JsonProperty("question")]
        public string QuestionType { get; set; }

        /// <summary>
        /// Gets or sets the question text.
        /// </summary>
        /// <value>
        /// The full text of a question.
        /// </value>
        [JsonProperty("questionText")]
        public string QuestionText { get; set; }
    }
}