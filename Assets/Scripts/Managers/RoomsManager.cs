using System.Collections;
using System.Collections.Generic;
using Rooms;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class RoomsManager : MonoBehaviourSingleton<RoomsManager>
    {
        private List<Room> rooms = new List<Room>();

        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }

        public Room PickRandomRoom()
        {
            return rooms[Random.Range(0, rooms.Count)];
        }
    }
}

