using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//This file is part of CSGO Inject tool.
//
//    CSGO Inject tool is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    CSGO Inject tool is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with CSGO Inject tool.  If not, see<http://www.gnu.org/licenses/>.

namespace CSGO_TOOL_FOR_DEBUG
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            label6.Text = "V." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
