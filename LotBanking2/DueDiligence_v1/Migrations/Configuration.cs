namespace DueDiligence_v1.Migrations
{
    using DueDiligence_v1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DueDiligence_v1.Models.DueDiligenceUIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DueDiligence_v1.Models.DueDiligenceUIContext context)
        {
            context.Proposals.AddOrUpdate(i => i.Builder,
            new BuilderProposal
            {

                Builder = "Bob",
                ProjectNumber = "A123",
                Legal = "Whatever goes Here",
                ProjectName = "Crux",
                MPC = "Same for Whatever",

                //Project Overview
                NumOfLots = 46,
                Acquisitions = 5.3,
                RollPrice = 350.00,
                OptionDeposit = 500000,
                Improvements = 6500,
                LoanToCost = 35000
            },

            new BuilderProposal
            {

                Builder = "Frank",
                ProjectNumber = "B234",
                Legal = "What does go here",
                ProjectName = "Epsilon",
                MPC = "Clueless",

                //Project Overview
                NumOfLots = 34,
                Acquisitions = 6.8,
                RollPrice = 475.00,
                OptionDeposit = 600000,
                Improvements = 45300,
                LoanToCost = 32000
            },

            new BuilderProposal
            {

                Builder = "Charlie",
                ProjectNumber = "C789",
                Legal = "Confizzled",
                ProjectName = "Delta",
                MPC = "Empty for nonsense",

                //Project Overview
                NumOfLots = 32,
                Acquisitions = 1.3,
                RollPrice = 150.00,
                OptionDeposit = 200000,
                Improvements = 3500,
                LoanToCost = 3000
            },

            new BuilderProposal
            {

                Builder = "Michael",
                ProjectNumber = "D123",
                Legal = "Something important",
                ProjectName = "GutterSpeak",
                MPC = "'ello 'ello",

                //Project Overview
                NumOfLots = 12,
                Acquisitions = 7.0,
                RollPrice = 50.00,
                OptionDeposit = 23000,
                Improvements = 600,
                LoanToCost = 125000
            },

            new BuilderProposal
            {

                Builder = "Maryland",
                ProjectNumber = "E456",
                Legal = "Perplexing Complexity",
                ProjectName = "Juniper",
                MPC = "Lost in Sauce",

                //Project Overview
                NumOfLots = 78,
                Acquisitions = 6.3,
                RollPrice = 930.00,
                OptionDeposit = 256000,
                Improvements = 234500,
                LoanToCost = 66000
            }
        );
        }
    }
}
