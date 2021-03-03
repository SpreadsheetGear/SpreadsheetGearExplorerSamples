/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using AutoMapper;
using SharedSamples;
using System.Linq;

namespace WebExplorer
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(dst => dst.SampleNames, opt => opt.MapFrom(src => src.SampleInfos.Select(si => si.Name)))
                .ForMember(dst => dst.Summary, opt => opt.MapFrom(src => src.GetCategorySummary(false)));
            CreateMap<SampleInfo, SampleInfoDTO>();
            CreateMap<SourceCodeItem, SourceCodeItemDTO>()
                .ForMember(dst => dst.SourceCode, opt => opt.MapFrom(src => src.GetSourceCode(3)));
        }
    }
}
