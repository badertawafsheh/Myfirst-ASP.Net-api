using first_web_api.DTOs.Character;
using first_web_api.DTOs.Weapon;
using first_web_api.Models;
using System.Threading.Tasks;

namespace first_web_api.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapn);



    }
}
