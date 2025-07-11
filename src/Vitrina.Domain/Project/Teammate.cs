﻿using System.ComponentModel.DataAnnotations;

namespace Vitrina.Domain.Project;

/// <summary>
/// Project users.
/// </summary>
public class Teammate
{
    /// <summary>
    /// User id.
    /// </summary>
    [Key]
    public int Id { get; private set; }

    /// <summary>
    /// User email.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// User name.
    /// </summary>
    required public string FirstName { get; set; }

    /// <summary>
    /// User last name.
    /// </summary>
    required public string LastName { get; set; }

    /// <summary>
    /// User patronymic.
    /// </summary>
    public string? Surname { get; set; }

    /// <summary>
    /// User avatar.
    /// </summary>
    public byte[]? Avatar { get; set; }

    /// <summary>
    /// User roles.
    /// </summary>
    public ICollection<ProjectRole> Roles { get; set; } = new List<ProjectRole>();

    /// <summary>
    /// User project id.
    /// </summary>
    public int ProjectId { get; set; }

    /// <summary>
    /// User project.
    /// </summary>
    required public Project Project { get; set; }
}
