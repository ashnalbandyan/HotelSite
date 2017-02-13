using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSite.Models
{
    public class OrderRoom
    {
        public int Id { get; set; }
        public RoomType RoomType { get; set; }
        public RoomsCount RoomsCount { get; set; }
        public GuestsCount GuestsCount { get; set; }
        public int Result { get; set; }
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