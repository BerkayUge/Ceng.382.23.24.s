using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectName.Pages
{
    public class AdditionModel : PageModel
    {
        [BindProperty]
        public int FirstNumber { get; set; }

        [BindProperty]
        public int SecondNumber { get; set; }

        public int? Result { get; set; }

        public void OnPost()
        {
            Result = FirstNumber + SecondNumber;
        }
    }
}
