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
            get => _positions; set
            {
                _positions = value;
                OnPropertyChanged(nameof(Positions));
            }
        }
        public ObservableCollection<Family> Families
        {
            get => _families; set
            {
                _families = value;
                OnPropertyChanged(nameof(Families));
            }
        }
        public ObservableCollection<Gender> Genders
        {
            get => _genders; set
            {
                _genders = value;
                OnPropertyChanged(nameof(Genders));
            }
        }
        public UserMaxDto? SelectedUser
        {
            get => _selectedUser; set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public string FirstName
        {
            get => firstName; private set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string MiddleName
        {
            get => middleName; private set
            {
                middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }
        public string LastName
        {
            get => lastName; private set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public Position? SelectedPosition
        {
            get => selectedPosition; private set
            {
                selectedPosition = value;
                OnPropertyChanged(nameof(SelectedPosition));
            }
        }
        public Gender? SelectedGender
        {
            get => selectedGender; private set
            {
                selectedGender = value;
                OnPropertyChanged(nameof(SelectedGender));
            }
        }
        public Family? SelectedFamily
        {
            get => selectedFamily; private set
            {
                selectedFamily = value;
                OnPropertyChanged(nameof(SelectedFamily));
            }
        }
        public int Age
        {
            get => age ?? 0; private set
            {
                age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
        public bool HasChildren
        {
            get => hasChildren; private set
            {
                hasChildren = value;
                OnPropertyChanged(nameof(HasChildren));
            }
        }
    }
}
