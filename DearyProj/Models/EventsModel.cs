namespace DearyPetProj.Models
{
    public class EventsModel
    {
        public List<UserEvent> Events { get; set; }

        public int UserId { get; set; }


        // Methods -- ---  --

        public List<UserEvent> GetUserEvents()
        {
            return new List<UserEvent>()
            {
                new UserEvent()
                {
                    Id = 0,
                    TimeEvent = $"{DateTime.Now}",
                    NameEvent = "Картоха тайм",
                    DescriptionEvent = "едем копать картоху, ух лять",
                    DateEvent = DateTime.Now,
                    CategoryEvent = "Приключенние",
                    TypeEvent = "Bad trip"
                },

                new UserEvent()
                {
                    Id = 0,
                    TimeEvent = $"{DateTime.Now.AddHours(1)}",
                    NameEvent = "Тусовка тайм",
                    DescriptionEvent = "едем тусить с картохой, ух лять",
                    DateEvent = DateTime.Now.AddHours(1),
                    CategoryEvent = "Отдых",
                    TypeEvent = "Chille"
                }
            };
        }


        public bool AddUserEvent()
        {
            return true;
        }


        public bool DeleteUserEvent()
        {
            return true;
        }


        public bool UpdateUserEvents()
        {
            return true;
        }
    }
}