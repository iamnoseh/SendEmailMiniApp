using Domain.DTOs.AdDTO;
using Domain.Entities.AdModels;

namespace Infrastructure.Services.AdServices;

public interface IAdService
{
    Task<bool> CreateAd(AdDto adDto);
    Task<bool> UpdateAd(UpdateAdDto updateAdDto);
    Task<bool> DeleteAd(int id);
    Task<AdDto?> GetAd(int id);
    Task<List<AdDto>> GetAds();
}