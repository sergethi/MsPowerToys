// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ColorPicker.Common;
using ColorPicker.Helpers;
using ColorPicker.Settings;
using ColorPicker.ViewModelContracts;
using ColorPicker.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ColorPicker.ViewModels.Tests
{
    [TestClass]
    public class ColorEditorViewModelTests
    {
        private Mock<IUserSettings>? _userSettingsMock;
        private ColorEditorViewModel? viewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            _userSettingsMock = new();
            _userSettingsMock.Setup(us => us.ColorHistory).Returns(new RangeObservableCollection<string>());
            _userSettingsMock.Setup(us => us.VisibleColorFormats).Returns([]);
            viewModel = new(_userSettingsMock.Object);
        }

        [TestMethod]
        public void DeleteAllColors_ShouldClearColorsHistory()
        {
            // Arrange
            Assert.IsNotNull(viewModel);
            viewModel.ColorsHistory.Add(Colors.Red);
            viewModel.ColorsHistory.Add(Colors.Green);
            viewModel.ColorsHistory.Add(Colors.Blue);
            Assert.AreEqual(3, viewModel.ColorsHistory.Count);

            // Act
            viewModel.RemoveAllColorsCommand.Execute(null);

            // Assert
            Assert.AreEqual(0, viewModel.ColorsHistory.Count);
        }
    }
}
