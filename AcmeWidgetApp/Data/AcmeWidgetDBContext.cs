using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeWidgetApp.Models.Registration;

namespace AcmeWidgetApp.Data
{
    public class AcmeWidgetDBContext: DbContext
    {
        public AcmeWidgetDBContext(DbContextOptions<AcmeWidgetDBContext> options)
        : base(options)
        {

        }

        public DbSet<ParticipantInfo> ParticipantInfo { get; set; }
        public DbSet<Activity> Activity { get; set; }
        
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>().HasData(new Activity
        {
            ActivityId = 1,
            ActivityName = "Board game tournament",
            Description = "A team-wide board game or card game tournament for some in-office fun. Includes prizes!"
        }, new Activity
        {
            ActivityId = 2,
            ActivityName = "Rock Climbing",
            Description = "test 2"
        }, new Activity
        {
            ActivityId = 3,
            ActivityName = "Escape room",
            Description = "Escape rooms can simulate office collaboration – they build the same leadership skills, teamwork, logic, and patience." +
            " No wonder they have become a popular team building exercise!"
        }, new Activity
        {
            ActivityId = 4,
            ActivityName = "Scavenger hunt",
            Description = "Scavenger Hunt Anywhere challenges you to a series of questions that you must answer correctly and in time in order to win! This is a great way to focus on skills related to communications, problem solving, strategy and the need to be creative. " +
            "This event also covers the history of Old Montreal and can be customized to meet the needs of your company"
        }, new Activity
        {
            ActivityId = 5,
            ActivityName = "Mud Racing",
            Description = "Get your unique mudding experience! Enjoy this awesome off-road racing experience, compete against other mudder truckers and win! Simple controls, a variety of obstacles to pass, " +
            "awesome cars and extreme tuning!"
        });

        }
    }
}

