/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using AutoMapper;
using SamplesLibrary;
using System.Linq;

namespace WebExplorer
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(dst => dst.SampleNames, opt => opt.MapFrom(src => src.SampleInfos.Select(si => si.Name)));
            CreateMap<SampleInfo, SampleInfoDTO>();
            CreateMap<SourceCodeItem, SourceCodeItemDTO>()
                .ForMember(dst => dst.SourceCode, opt => opt.MapFrom(src => src.GetSourceCode(SourceCodeFormat.Plaintext, 3)));
        }
    }
}
