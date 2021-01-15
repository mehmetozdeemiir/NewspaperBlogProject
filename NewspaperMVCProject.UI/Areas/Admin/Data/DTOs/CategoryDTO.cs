using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewspaperMVCProject.UI.Areas.Admin.Data.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Boş Geçmeyiniz....")]
        public string Name { get; set; }
    }
}