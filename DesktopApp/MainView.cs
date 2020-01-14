﻿using DesktopApp.Views;
using Model.DataAccess.Daos.Interfaces;
using Model.DataAccess.Entity;
using Model.Model;
using Model.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class MainView : Form
    {
        private readonly IToDoListService _toDoListService;
        private readonly IToDoListDao _toDoListDao;
        private readonly IToDoItemDao _toDoItemDao;
        private IList<ToDoListModel> _toDoListModels;
        private ToDoListModel _currentToDoList; 

        public MainView(IToDoListService toDoListService, IToDoListDao toDoListDao, IToDoItemDao toDoItemDao)
        {
            InitializeComponent();

            _toDoListService = toDoListService;
            _toDoListDao = toDoListDao;
            _toDoItemDao = toDoItemDao;

            _toDoListModels = _toDoListService.PopulateToDoListCache().Select(tdl => new ToDoListModel(tdl)).ToList(); 
            var currentList = _toDoListModels.FirstOrDefault(tdlm => tdlm.Date.ToShortDateString() == DateTime.Now.ToShortDateString())
                              ?? _toDoListModels.OrderByDescending(tdlm => tdlm.Date).FirstOrDefault();
            _currentToDoList = currentList;

            var toDoListControl = new ToDoListControl(currentList, _toDoListService, _toDoListDao, _toDoItemDao);
            flowLayoutPanel1.Controls.Add(toDoListControl);
        }

        private void MainView_Load(object sender, EventArgs e)
        {

        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            SwitchListControls(forward: false);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            SwitchListControls(forward: true);
        }

        private void SwitchListControls(bool forward)
        {
            var nextList = _toDoListService.PickNextToDoList(_currentToDoList, forward);
            var nextListModel = new ToDoListModel(nextList);
            _currentToDoList = nextListModel;
            var toDoListControl = new ToDoListControl(nextListModel, _toDoListService, _toDoListDao, _toDoItemDao);
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(toDoListControl);
        }
    }
}
