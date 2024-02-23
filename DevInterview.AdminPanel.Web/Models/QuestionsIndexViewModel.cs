namespace DevInterview.AdminPanel.Web.Models
{
    public class QuestionsIndexViewModel
    {
        public string SelectedRoleId { get; set; }
        public string SelectedTopicId { get; set; }
        public List<RoleViewModel> RoleList { get; set; } = new();
        public QuestionViewModel Question { get; set; }

    }
}
