using Microsoft.AspNetCore.Identity;
using PaintyTask.Models.DTO;

namespace PaintyTask.Models.DB;

public class DbAppUser : IdentityUser
{
    private HashSet<Image> _images;

    IReadOnlyCollection<Image> Images
    {
        get => _images;
        set => _images = value.ToHashSet();
    }
}