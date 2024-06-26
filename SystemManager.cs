﻿using LoanManagementSys.Managers;
using LoanManagementSys.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys
{
    internal class SystemManager
    {
        //make threads here. instantiate all managers and tasks. run tasks through threads.

        
            public MemberManager mm;
            public ProductManager pm;
            public LoanManager lm;
            UpdateGUI updateGUI;
            AdminTask AT;
            LoanTask LT;
            ReturnTask RT;
            public MainForm mainForm;
            public Thread GUIThread;
            public Thread LoanThread;
            public Thread AdminThread;
            public Thread ReturnThread;
            public bool stop = false;

            public SystemManager(MainForm mainForm) 
            {
                mm = new MemberManager();
                pm = new ProductManager();
                lm = new LoanManager(pm, mm);
                this.mainForm = mainForm;
                AT = new AdminTask(pm);
                LT = new LoanTask(lm);
                RT = new ReturnTask(lm);
                updateGUI = new UpdateGUI(this, mainForm);
                InitializeProgram();
                MakeThreads();
                
            }

            public void InitializeProgram()
            {
                pm.AddTestProducts();
                mm.addTestMember();
            }

            public void MakeThreads()
            {
                AdminThread = new Thread(AT.Run);
                LoanThread = new Thread(LT.Run);
                ReturnThread = new Thread(RT.Run);
            GUIThread = new Thread(updateGUI.Run);
            GUIThread.Start();
                AdminThread.Start();
                LoanThread.Start();
                ReturnThread.Start();
            }

            public void LiveThreads()
            {
                
                AT.Running = true;
                LT.Running = true;
                RT.Running = true;
            updateGUI.isRunning = true;
        }

            public void KillThreads()
            {
                
                AT.Running = false;
                LT.Running = false;
                RT.Running = false;
            updateGUI.isRunning = false;
        }



        

    }
}
