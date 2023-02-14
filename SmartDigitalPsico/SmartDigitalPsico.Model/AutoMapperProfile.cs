using AutoMapper;
using SmartDigitalPsico.Model.Dto.User;
using SmartDigitalPsico.Model.Entity;

namespace SmartDigitalPsico.Model
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
        //    CreateMap<Character, GetCharacterDto>();
        //    CreateMap<AddCharacterDto, Character>();
        //    CreateMap<Weapon, GetWeaponDto>();
        //    CreateMap<Skill, GetSkillDto>();            
        //    CreateMap<Character, HighscoreDto>();
            CreateMap<User, GetUserDto>();
        }
    }
}