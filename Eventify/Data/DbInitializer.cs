using Eventify.Common;
using System.Diagnostics;

namespace Eventify.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var events = new Events[]
            {
                new Events{EventName="CSS Day", Status="Ongoing",Date=DateTime.Parse("2024-09-01"), StartTime=TimeOnly.Parse("12:00"), EndTime=TimeOnly.Parse("17:00"), Venue="ACT 3rd Floor", ACCESS_CODE=AccessCode.CreateAccessCode()},
            };

            context.Events.AddRange(events);
            context.SaveChanges();


            var activities = new Activity[]
            {
                new Activity{EventID=1, Name="Esports",Date=DateTime.Parse("2024-09-01"), StartTime=TimeOnly.Parse("12:00"), EndTime=TimeOnly.Parse("17:00"), Venue="ACT 3rd Floor"},
                new Activity{EventID=1, Name="Programming",Date=DateTime.Parse("2024-09-01"), StartTime=TimeOnly.Parse("12:00"), EndTime=TimeOnly.Parse("17:00"), Venue="ACT 3rd Floor"},
                new Activity{EventID=1, Name="Graphic Design",Date=DateTime.Parse("2024-09-01"), StartTime=TimeOnly.Parse("12:00"), EndTime=TimeOnly.Parse("17:00"), Venue="ACT 3rd Floor"},
            };

            context.Activity.AddRange(activities);
            context.SaveChanges();


            var participants = new Participants[]
            {
                new Participants{Name="John Doe", Course="Computer Science", Section="CS601", EntryNumber="01", ActivityID=1},
                new Participants{Name="Parsley Montana", Course="Computer Science", Section="CS601", EntryNumber="02", ActivityID=1},
                new Participants{Name="Bartholomew Shoe", Course="Computer Science", Section="CS601", EntryNumber="03", ActivityID=1},
                new Participants{Name="Ruby Von Rails", Course="Computer Science", Section="CS601", EntryNumber="04", ActivityID=1},
                new Participants{Name="Eric Widget", Course="Computer Science", Section="CS601", EntryNumber="05", ActivityID=1},
                new Participants{Name="Weir Doe", Course="Computer Science", Section="CS601", EntryNumber="06", ActivityID=1},
                new Participants{Name="Fleece Marigold", Course="Computer Science", Section="CS601", EntryNumber="07", ActivityID=1},
            };

            context.Participants.AddRange(participants);
            context.SaveChanges();
        }
    }
}
