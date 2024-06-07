using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class Images
  {
    [Key]
    public int ImageID { get; set; } 

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public string SecretEditLink { get; set; } = string.Empty;
    public DateTime UploadDate { get; set; }
    public Users? UserID { get; set; }
    public Categories? CategoryID { get; set; }
  }
}