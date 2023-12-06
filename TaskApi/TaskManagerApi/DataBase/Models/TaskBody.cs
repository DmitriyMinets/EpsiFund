using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{

    public class TaskBody
    {
        [DefaultValue("")]
        public string Title { get; set; }
        [DefaultValue("")]
        public string? Description { get; set; }
    }
}
