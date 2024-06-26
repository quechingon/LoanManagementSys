﻿using LoanManagementSys.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys.Tasks
{
    internal class LoanTask : ParentTask
    {
        LoanManager lm;
        public LoanTask(LoanManager lm) 
        {
            this.lm = lm;
        }

        public void Run()
        {
            while(isRunning)
            {
                //Runs on associated thread.
                //Loans a random item to a random member.
                lm.AddItem();
                Thread.Sleep(rndTimer.Next(1000, 15000));
            }
        }
    }
}
