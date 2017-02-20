using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using HotelSite.Resources;
using System.ComponentModel.DataAnnotations;

namespace HotelSite.Models
{
    public class OrderRoom
    {
        public int Id { get; set; }
        [Display(Name = "RoomType", ResourceType = typeof(Home))]
        public RoomType RoomType { get; set; }
        [Display(Name = "RoomsCount", ResourceType = typeof(Home))]
        public RoomsCount RoomsCount { get; set; }
        [Display(Name = "GuestsCount", ResourceType = typeof(Home))]
        public GuestsCount GuestsCount { get; set; }
        [Display(Name = "Result", ResourceType = typeof(Home))]
        public int Result { get; set; }
        public bool IsReserved { get; set; }
    }
    
    public enum RoomType
    {
        Comfort = 100,
        Security = 150,
        Privacy = 200,
        Convenience = 250,
        Lux = 300
    }
    public enum RoomsCount
    {
        Single = 20,
        Double = 30,
        Interconnecting = 40,
        Douplex = 50
    }
    public enum GuestsCount
    {
       One = 5,
       Two = 10,
       Three = 15,
       Four = 20,
       Five = 25

    }
}