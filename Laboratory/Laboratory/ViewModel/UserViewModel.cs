using Laboratoty.Data.DTOs;
using Laboratoty.Data.Entities;
using Laboratoty.Data.Services;
using Laboratoty.ViewModel.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoty.ViewModel
{
    public class UserViewModel : ObservableObject
    {
        private UserService _userService;
        private PositionService _positionService;
        private GenderService _genderService;
        private FamilyService _familyService;
        public UserViewModel(UserService service, PositionService positionService, GenderService genderService, FamilyService familyService)
        {

            _userService = service;
            var tableNames = _userService._context.Model.GetEntityTypes().Select(t => t.GetTableName()).ToList();
            _users = new ObservableCollection<UserMaxDto>(_userService.GetUsersFull());
            _positionService = positionService;
            Positions = new ObservableCollection<Position>(_positionService.GetPositions());
            _genderService = genderService;
            Genders = new ObservableCollection<Gender>(_genderService.GetGenders());
            _familyService = familyService;
            Families = new ObservableCollection<Family>(_familyService.GetFamilies());
        }

        private RelayCommand? addUserCommand = null;
        public RelayCommand AddUserCommand
        {
            get
            {
                return addUserCommand ??
                  (addUserCommand = new RelayCommand(obj =>
                  {
                      if (SelectedPosition != null && SelectedGender != null && SelectedFamily != null)
                          _userService.AddUser(
                              new AddUserDto(
                                  FirstName,
                                  MiddleName,
                                  LastName,
                                  Age,
                                  HasChildren,
                                  SelectedPosition.Id,
                                  SelectedGender.Id,
                                  SelectedFamily.Id
                                  ));
                  }));
            }
        }

        private RelayCommand? editUserCommand = null;
        public RelayCommand EditUserCommand
        {
            get
            {
                return editUserCommand ??
                  (editUserCommand = new RelayCommand(obj =>
                  {
                      if (SelectedUser != null)
                          _userService.EditUser(
                              SelectedUser.Id,
                              new EditUserDto(
                                  FirstName,
                                  MiddleName,
                                  LastName,
                                  Age,
                                  HasChildren,
                                  SelectedPosition.Id,
                                  SelectedGender.Id,
                                  SelectedFamily.Id
                                  ));
                  }));
            }
        }

        private RelayCommand? deleteUserCommand;
        public RelayCommand DeleteUserCommand
        {
            get
            {
                return deleteUserCommand ??
                  (deleteUserCommand = new RelayCommand(obj =>
                  {
                      if (SelectedUser != null)
                          _userService.DeleteUser(SelectedUser.Id);

                  }));
            }
        }

        private string firstName = "";
        private string middleName = "";
        private string lastName = "";
        private Position? selectedPosition = null;
        private Gender? selectedGender = null;
        private Family? selectedFamily = null;
        private int? age = null;
        private bool hasChildren = false;
        private ObservableCollection<UserMaxDto> _users = [];
        private ObservableCollection<Position> _positions = [];
        private ObservableCollection<Family> _families = [];
        private ObservableCollection<Gender> _genders = [];
        private UserMaxDto? _selectedUser = null;


        public ObservableCollection<UserMaxDto> Users
        {
            get => _users; set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public ObservableCollection<Position> Positions
        {
            get => _positions; 
            set
            {
                _positions = value;
                OnPropertyChanged("Positions");
            }
        }
        public ObservableCollection<Family> Families
        {
            get => _families; set
            {
                _families = value;
                OnPropertyChanged("Families");
            }
        }
        public ObservableCollection<Gender> Genders
        {
            get => _genders; set
            {
                _genders = value;
                OnPropertyChanged("Genders");
            }
        }
        public UserMaxDto? SelectedUser
        {
            get => _selectedUser; set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        public string FirstName
        {
            get => firstName;   set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string MiddleName
        {
            get => middleName;
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }
        public string LastName
        {
            get => lastName;   set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public Position? SelectedPosition
        {
            get => selectedPosition;   set
            {
                selectedPosition = value;
                OnPropertyChanged("SelectedPosition");
            }
        }
        public Gender? SelectedGender
        {
            get => selectedGender;   set
            {
                selectedGender = value;
                OnPropertyChanged("SelectedGender");
            }
        }
        public Family? SelectedFamily
        {
            get => selectedFamily;   set
            {
                selectedFamily = value;
                OnPropertyChanged("SelectedFamily");
            }
        }
        public int Age
        {
            get => age ?? 0;   set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        public bool HasChildren
        {
            get => hasChildren;   set
            {
                hasChildren = value;
                OnPropertyChanged("HasChildren");
            }
        }
    }
}
