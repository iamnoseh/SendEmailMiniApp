using AutoMapper;
using Domain.DTOs.AdDTO;
using Domain.Entities.AdModels;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.AdServices;

public class AdService(DataContext context,IMapper mapper):IAdService
{
    public async Task<bool> CreateAd(AdDto adDto)
    {
        var ad = mapper.Map<Ad>(adDto);
        await context.Ads.AddAsync(ad);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAd(UpdateAdDto updateAdDto)
    {
        var ad = await context.Ads.FirstOrDefaultAsync(x=> x.Id == updateAdDto.Id);
        if (ad == null) return false;
        mapper.Map(updateAdDto, ad);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAd(int id)
    {
        var ad = await context.Ads.FirstOrDefaultAsync(x => x.Id == id);
        context.Ads.Remove(ad);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<AdDto?> GetAd(int id)
    {
        var ad = context.Ads.FirstOrDefaultAsync(x => x.Id == id);
        var adDto = mapper.Map<AdDto>(ad);
        return adDto;
    }

    public async Task<List<AdDto>> GetAds()
    {
        var ads = context.Ads.ToList();
        var adsDto = mapper.Map<List<AdDto>>(ads);
        return adsDto;
    }
}