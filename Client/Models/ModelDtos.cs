using System.ComponentModel.DataAnnotations;

namespace Client.Models;

public record LoginModel
{
    [Required]
    public string Username { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";
}

public record PassowrdRenewalRequestModelDto
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string? Email { get; set; }
}
public record PasswordResetModelDto
{
    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword { get; set; }
}

public record RegisterModelDto
{
    [Display(Name = "Name")]
    public string? Name { get; set; }
    [Display(Name = "Surname")]
    public string? Surname { get; set; }
    [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [Display(Name = "Audiance")]
    public string? Username { get; set; }
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword { get; set; }
}

public record ResetPasswordDto
{
    public string Email { get; set; }
    public string Token { get; set; }
    public string NewPassword { get; set; } 
}
public record AddCommentModelDto(int? ParentCommentId,int TopicId, string Body);

public record UpdateCommentModelDto(string Body);

public record TopicModelDto
{
    public int ForumId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; } 


};

public record UpdateTopicModelDto(int id,string title, string body)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string Body { get; set; } = body;


};

public record CreateForumModelDto 
{ 

    public string Title { get; set; }
}
public record UpdateForumDto(int Id,string Title);

public record NotificationDto(string audiance, string notificationbody) 
{
    public string Audiance { get; set; } = audiance;
    public string Notificationbody { get; set; } = notificationbody;

};
