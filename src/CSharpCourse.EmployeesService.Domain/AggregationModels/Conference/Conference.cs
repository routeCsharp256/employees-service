using System;
using System.Collections.Generic;
using CSharpCourse.EmployeesService.Domain.Root;

namespace CSharpCourse.EmployeesService.Domain.AggregationModels.Conference
{
    /// <summary>
    /// Сущность Entity для конференции
    /// </summary>
    public class Conference : Entity<long>
    {
        // private Conference(Name name, CreateDate createDate, ConferenceDate conferenceDate, Description description)
        // {
        //     Name = name;
        //     CreateDate = createDate;
        //     ConferenceDate = conferenceDate;
        //     Description = description;
        // }

        // private Conference(long id, string name, DateTime createDate, DateTime conferenceDate, string description)
        // {
        //     Id = id;
        //     Name = new Name(name);
        //     CreateDate = new CreateDate(createDate);
        //     ConferenceDate = new ConferenceDate(conferenceDate);
        //     Description = new Description(description);
        // }

        public override long Id { get; protected set; }

        /// <summary>
        /// Name of conference
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Create date of the conference
        /// </summary>
        public CreateDate CreateDate { get; private set; }

        /// <summary>
        /// Date of the conference
        /// </summary>
        public ConferenceDate ConferenceDate { get; private set; }

        /// <summary>
        /// Conference description
        /// </summary>
        public Description Description { get; private set; }


        public static Conference CreateConference(string name, DateTime createDate, DateTime conferenceDate,
            string description)
        {
            var conference = new Conference
            {
                Id = 0,
                Name = new Name(name),
                CreateDate = new CreateDate(createDate),
                ConferenceDate = new ConferenceDate(conferenceDate),
                Description = new Description(description)
            };

            return conference;
        }

        public Conference ChangeConferenceDate(ConferenceDate conferenceDate)
        {
            this.ConferenceDate = conferenceDate;
            return this;
        }

        public ICollection<EmployeeConference> EmployeeConferences { get; private set; }
    }
}
