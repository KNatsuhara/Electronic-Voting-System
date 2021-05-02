﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_Voting_System
{
    public class Election
    {
        public string start_date{ get; set;}
        public string end_date{ get; set;}
        public double min_win_percentage{ get; set;}
        public bool is_active{ get; set;}
        private List<Candidate> candidate_list; 

        public Election()
        {
            candidate_list = new List<Candidate>();
            this.start_date = string.Empty;
            this.end_date = string.Empty;
            this.min_win_percentage = 0;
            this.is_active = false;
        }

        public Election(List<Candidate> list)
        {
            candidate_list = list;
            this.start_date = string.Empty;
            this.end_date = string.Empty;
            this.min_win_percentage = 0;
            this.is_active = false;
        }

        public Election(List<Candidate> list, string start, string end, double min_win)
        {
            candidate_list = list;
            start_date = start;
            end_date = end;
            min_win_percentage = min_win;
            this.is_active = false;
        }

        public List<Candidate> GetCandidates()
        {
            return this.candidate_list;
        }

        // adds 1 vote to the inputted candidate name. 
        // will 100% produce a logic error if 2+ candidates have the same name lol
        public void addVote(string candidate_name)
        {
            foreach (Candidate current in candidate_list)
            {
                if (current.name == candidate_name)
                {
                    current.addVote();
                }
            }
        }

        public void startElection()
        {
            is_active = true;
        }

        public void stopElection()
        {
            is_active = false;
        }

        public void sortByVotes()
        {
            candidate_list.Sort((x, y) => y.total_votes.CompareTo(x.total_votes));
        }

        public void displaySettings()
        {
            Console.WriteLine("---- Election Settings ----\n");
            Console.WriteLine("Start date: " + start_date);
            Console.WriteLine("End date: " + end_date);
            Console.WriteLine("Minimum Win Percentage: " + min_win_percentage);
            Console.WriteLine("IsActive: " + is_active);
            Console.WriteLine("--- Candidates ---");
            foreach (Candidate curr in candidate_list)
            {
                Console.WriteLine(curr.name + "\t" + curr.party);
            }
        }

        public void checkElection(int total_voters, string current_date)
        {
            this.sortByVotes();
            // check if minimum win percentage has been reached by the candidate with the most votes
            if ((this.candidate_list[0].total_votes / total_voters) * 100 > this.min_win_percentage)
            {
                this.stopElection();
            }
            // check if the deadline has arrived
            if (current_date == this.end_date)
            {
                this.stopElection();
            }
        }


    }
}
