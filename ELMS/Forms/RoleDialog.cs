using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ELMS.Models;
using ELMS.Services;

namespace ELMS.Forms
{
    public partial class RoleDialog : Form
    {
        private readonly Role? _editingRole;

        public RoleDialog(Role? roleToEdit = null)
        {
            _editingRole = roleToEdit;
            InitializeComponent();
            PopulatePermissions();

            if (_editingRole != null)
            {
                lblHeader.Text = "Edit Role";
                txtRoleName.Text = _editingRole.Name;
                txtRoleKey.Text = _editingRole.RoleKey;
                txtRoleKey.ReadOnly = _editingRole.IsSystemRole;
                txtDescription.Text = _editingRole.Description;
                chkIsActive.Checked = _editingRole.IsActive;

                for (int i = 0; i < chkPermissionsList.Items.Count; i++)
                {
                    string p = chkPermissionsList.Items[i]?.ToString() ?? "";
                    if (_editingRole.Permissions.Contains(p))
                    {
                        chkPermissionsList.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void PopulatePermissions()
        {
            chkPermissionsList.Items.Clear();
            foreach (var perm in PermissionCatalog.All)
            {
                chkPermissionsList.Items.Add(perm.Key);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtRoleName.Text.Trim();
            string key = txtRoleKey.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Role name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                key = "ROLE_" + name.ToUpperInvariant().Replace(" ", "_");
            }

            var selectedPerms = new List<string>();
            foreach (var item in chkPermissionsList.CheckedItems)
            {
                selectedPerms.Add(item.ToString() ?? "");
            }

            if (_editingRole == null)
            {
                int newId = DataStore.Instance.Roles.Any() ? DataStore.Instance.Roles.Max(r => r.Id) + 1 : 1;
                var newRole = new Role
                {
                    Id = newId,
                    Name = name,
                    RoleKey = key,
                    Description = txtDescription.Text.Trim(),
                    IsActive = chkIsActive.Checked,
                    Permissions = selectedPerms,
                    UserCount = 0,
                    IsSystemRole = false
                };
                DataStore.Instance.Roles.Add(newRole);
            }
            else
            {
                _editingRole.Name = name;
                if (!_editingRole.IsSystemRole) _editingRole.RoleKey = key;
                _editingRole.Description = txtDescription.Text.Trim();
                _editingRole.IsActive = chkIsActive.Checked;
                _editingRole.Permissions = selectedPerms;
            }

            DataStore.Instance.NotifyChanged();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}