using DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface IClassroomRepo
    {
        Task<int> UpdateTeamsToken(TeamsToken data);
        Task<TeamsToken> GetTeamsToken();
        Task<dynamic> GetInitatorInfo(Guid initiatorId);
        Task<int> AddRoomWithAttendees(Rooms room);
        Task<List<vwRoomAttendees>> GetStudentRoom(Guid ProfileID);
        Task<Rooms> AddRoom(Rooms room);
        Task<RoomAttendees> AddAttendeesToRoom(RoomAttendees attendees);
        Task<bool> ClearAttendeesRoom(string roomId, Guid initiatorId);
        Task<Rooms> EditRoom(Rooms room);
        Task<List<Rooms>> GetRooms(Guid initiatorId);
        Task<bool> GetRoom(string roomId);
        Task<Rooms> GetRoomById(int Id);
        Task<bool> DeleteRoom(int Id, Guid initiatorId);
        Task<bool> UpdateRoomState(int Id, bool isActive);
        Task<bool> EndMeeting(string roomId, Guid initiatorId);

        Task<Chats> AddChat(Chats chat);
        Task<List<Chats>> GetChats(Guid initatorId);
        Task<List<Chats>> GetChat(string roomId, string sessionId, Guid initiatorId);

        Task<Recordings> InsertRecording(string roomId, string filename, Guid initiatorId);
        Task<bool> DeleteRecording(int recordingId);
        Task<List<Recordings>> GetRecordings();

        Task<Rooms> LoginAdmin(UserDetails userDetails, string roomId);
        Task<RoomAttendees> LoginUser(UserDetails userDetails, string roomId);
        Task<bool> BlockUser(string roomId, string emailAddress);


        Task<Feedbacks> AddFeedback(Feedbacks feedbacks);

        Task<IEnumerable<dynamic>> GetClassGroupStudents(Guid classGroupId);
    }
}
