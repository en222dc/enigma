using Enigma.Models;
using Enigma.Models.Repositories;
using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
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
            EncryptKillerName(ListOfSuspects);

            GoToPageCommand = new RelayCommand(GoToPuzzlePage);
            ExitButtonContent = "Exit to Start Page";
            MyWindow.MenuFrame.Content = new MenuPage();
        }

        public BackStoryViewModel()
        {
            GoToPageCommand = new RelayCommand(GoToPuzzlePage);
            BackStoryText = $"The president of Russia has assigned {MyPlayer.Player_name} to solve the mysterious murder of his wife Katja. \nThe police has no suspects and are totally perplexed. \nThe only clue at your disposal" +
                " is a series of puzzles found at the crime scene. \nIf the puzzle is too challenging you have the option to display a hint which could help you in solving the puzzle, this will however add 60 seconds to your time. \n\n\n\t\tWill You be the player who finds the killer the fastest?";
        }
        #endregion

        #region Navigation
        public void GoToPuzzlePage()
        {
         var model = new PuzzlePageViewModel();
         var page = new PuzzlePage(model);
         NavigationService.Navigate(page);
        }
        #endregion

        #region Methods
        private ObservableCollection<Suspect> GetAllSuspects()
        {
            ObservableCollection<Suspect> Templist = new ObservableCollection<Suspect>();
            foreach (var suspect in Repository.GetAllSuspects())
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

        public void EncryptKillerName(ObservableCollection<Suspect> listOfSuspects)
        {
            string killerName = "";
            for (int suspect = 0; suspect < listOfSuspects.Count; suspect++)
            {
                if (listOfSuspects[suspect].IsKiller)
                {
                    killerName = listOfSuspects[suspect].Name;
                    listOfSuspects[suspect].EncryptedName = new char[listOfSuspects[suspect].Name.Length];
                    foreach (KeyValuePair<string, string> pair in SymbolAlphabet.TranslateMySymbolsToLetters)
                    {
                        killerName = killerName.ToLower().Replace(pair.Value, pair.Key);
                    }

                    for (int i = 0; i < killerName.Length; i++)
                    {
                        foreach (char c in killerName)
                        {
                            listOfSuspects[suspect].EncryptedName[i] = c;
                            i++;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
