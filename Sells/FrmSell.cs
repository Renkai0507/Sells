﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sells
{
    public partial class FrmSell : Form
    {
        IDbServiceWrapper Db;
        public FrmSell(IDbServiceWrapper Db)
        {
            InitializeComponent();
        }
    }
}
