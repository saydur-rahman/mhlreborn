using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StairEstate.Entity.View_Model
{
    public class LandBasicInfoVm
    {
        public LandBasicInfoVm(prop_Land_Contribution landBasicInfo)
        {
            Id = landBasicInfo.Land_Con_id;
            BranchId = (int)landBasicInfo.Land_Con_branch_Id;
            LandMasterId = landBasicInfo.Land_Con_Auto_id;
            ProjectId = (int)landBasicInfo.Land_Con_Project_id;
            ProjectTypeId = landBasicInfo.proj_project.project_type_id;

            Lands = new HashSet<LandVm>();

            foreach (var land in landBasicInfo.prop_Land)
            {
                Lands.Add(new LandVm(land));
            }
        }

        public LandBasicInfoVm()
        {
            Lands = new HashSet<LandVm>();
        }

        public int Id { get; set; }

        public int BranchId { get; set; }

        [Required]
        public string LandMasterId { get; set; }
        [Required]
        public int  ProjectId { get; set; }
        [Required]
        public HashSet<LandVm> Lands { get; set; }

        public int? ProjectTypeId { get; set; }
        
    }

    public class LandVm
    {
        public LandVm(prop_Land land)
        {
            Id = land.Land_id;
            Area = (float)land.Land_Area;
            MouzaId = (int) land.Land_Mouza_id;
            JLNo = land.Land_JL_no;
            KhatianNo = land.Land_JL_no;
            Dag = land.Land_Dag_no;
            UnitId = (int)land.Land_Unit_id;
            Rate = (float) land.Land_Rate_Per_Dag;

            Owners = new HashSet<OwnerVm>();
            Medias = new HashSet<MediaVm>();

            foreach (var owner in land.prop_Land_LandOwner)
            {
                Owners.Add(new OwnerVm(owner));
            }

            foreach (var media in land.prop_Land_Media)
            {
                Medias.Add(new MediaVm(media));
            }

            Mouza = land.sys_mouza.Mouza_name;
            Thana = land.sys_mouza.sys_thana.Thana_name;
            District = land.sys_mouza.sys_thana.sys_district.District_Name;
            ThanaId = land.sys_mouza.Mouza_Thana_id;
            DisTrictId = land.sys_mouza.sys_thana.Thana_District_id;
        }

        public LandVm()
        {
            Owners = new HashSet<OwnerVm>();
            Medias = new HashSet<MediaVm>();
        }

        public int Id { get; set; }
        [Required]
        public int MouzaId { get; set; }
        [Required]
        public string JLNo { get; set; }
        [Required]
        public string KhatianNo { get; set; }
        [Required]
        public string Dag { get; set; }
        [Required]
        public float Area { get; set; }
        [Required]
        public int UnitId { get; set; }
        [Required]
        public float Rate { get; set; }
        [Required]
        public HashSet<OwnerVm> Owners { get; set; }
        [Required]
        public HashSet<MediaVm> Medias { get; set; }

        public string Mouza { get; set; }
        public string Thana { get; set; }
        public string District { get; set; }

        public int? ThanaId { get; set; }
        public int? DisTrictId { get; set; }

    }

    public class OwnerVm
    {
        public OwnerVm(prop_Land_LandOwner owner)
        {
            Id = owner.id;
            OwnerId = owner.Land_Owner;
            LandId = owner.Land_Id;
        }

        public OwnerVm()
        {
            
        }

        public int Id { get; set; }

        public int? OwnerId { get; set; }
        public int? LandId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
    }

    public class MediaVm
    {
        public MediaVm(prop_Land_Media media)
        {
            Id = media.id;
            MediaId = media.Land_media;
            LandId = media.Land_id;
        }

        public MediaVm()
        {
            
        }

        public int Id { get; set; }

        public int? MediaId { get; set; }
        public int? LandId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
    }


}
