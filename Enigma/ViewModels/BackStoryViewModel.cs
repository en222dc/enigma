﻿using Enigma.Models;
using Enigma.Models.Repositories;
using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    public class BackStoryViewModel : BaseViewModel
    {
        #region Properties
        public string BackStoryText { get; set; }
        public ICommand GoToPageCommand { get; set; }
        #endregion

        #region Constructors
        public BackStoryViewModel(Player player)
        {
            ListOfSuspects = GetAllSuspects();
            SetKiller(ListOfSuspects);
            SetEncryptedKillerName(ListOfSuspects);

            GoToPageCommand = new RelayCommand(GoToPuzzlePage);
            ExitButtonContent = "Exit to Start Page";
            MyWindow.MenuFrame.Content = new MenuPage();
        }

        public BackStoryViewModel()
        {
            GoToPageCommand = new RelayCommand(GoToPuzzlePage);
            BackStoryText = $"The president of Russia has assigned {MyPlayer.Player_name} to solve the mysterious murder of his wife Katja. \nThe police has no suspects and are totally perplexed. \n\nThe only clue at your disposal" +
                " is a series of puzzles found at the crime scene. \n\nIf the puzzle is too challenging you have the option to display a hint which could help you in solving the puzzle, this will however add 60 seconds to your time. \n\nWill You be the player who finds the killer the fastest?";
        }
        #endregion

        #region Navigation
        public void GoToPuzzlePage()
        {
         var model = new PuzzleViewModel();
         var page = new PuzzlePage(model);
         NavigationService.Navigate(page);
        }
        #endregion

        #region Methods
        private ObservableCollection<Suspect> GetAllSuspects()
        {
            ObservableCollection<Suspect> Templist = new ObservableCollection<Suspect>();
            foreach (var suspect in Repository.GetAllSuspectsFromDb())
            {
                Templist.Add(suspect);
            }
            return Templist;
        }

        private void SetKiller(ObservableCollection<Suspect> listOfSuspects)
        {
            Random random = new Random();
            int index;
            index = random.Next(listOfSuspects.Count);
            listOfSuspects[index].IsKiller = true;
            MyKiller = listOfSuspects[index];
        }

        public void SetEncryptedKillerName(ObservableCollection<Suspect> listOfSuspects)
        {
            string killerName = "";
            for (int suspect = 0; suspect < listOfSuspects.Count; suspect++)
            {
                if (listOfSuspects[suspect].IsKiller)
                {
                    killerName = listOfSuspects[suspect].KillerName;
                    listOfSuspects[suspect].EncryptedNameOfKiller = new char[listOfSuspects[suspect].KillerName.Length];
                    foreach (KeyValuePair<string, string> pair in SymbolAlphabet.TranslateMySymbolsToLetters)
                    {
                        killerName = killerName.ToLower().Replace(pair.Value, pair.Key);
                    }

                    for (int i = 0; i < killerName.Length; i++)
                    {
                        foreach (char c in killerName)
                        {
                            listOfSuspects[suspect].EncryptedNameOfKiller[i] = c;
                            i++;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
