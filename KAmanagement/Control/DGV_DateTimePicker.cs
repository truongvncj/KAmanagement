using System;

using System.Windows.Forms;

namespace KAmanagement.Control
{
    class DGV_DateTimePicker
    {

        public class DateTimePickerColumn : DataGridViewColumn
        {
            public DateTimePickerColumn()
                : base(new DateTimePickerCell())
            {
            }

            public override DataGridViewCell CellTemplate
            {
                get
                {
                    return base.CellTemplate;
                }
                set
                {
                    // Ensure that the cell used for the template is a DateTimePickerCell.
                    if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof(DateTimePickerCell)))
                    {
                        throw new InvalidCastException("Must be a DateTimePickerCell");
                    }
                    base.CellTemplate = value;
                }
            }
        }

        public class DateTimePickerCell : DataGridViewTextBoxCell
        {

            public DateTimePickerCell()
                : base()
            {
                // Use the custom defined date format.
                this.Style.Format = "dd.MM.yyyy";
            }

            public override void InitializeEditingControl(int rowIndex, object
                initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue,
                    dataGridViewCellStyle);

                DateTimePickerEditingControl ctl = (DateTimePickerEditingControl)DataGridView.EditingControl;
                DateTime d;
                ctl.Value = DateTime.TryParse((Value ?? "").ToString(), out d) ? d : DateTime.Now;

                /*Check whether the datagridview is databound/unbound. In both cases if the value of the cell
             isn't null then check the DateTimePickerEditing Control else uncheck it.*/
                if (ctl.EditingControlDataGridView.CurrentCell.OwningColumn.IsDataBound)
                    ctl.Checked = Value.ToString() == "" ? false : Value == null ? false : true;
                else
                    ctl.Checked = Value == null ? false : true;
            }

            public override Type EditType
            {
                get
                {
                    // Return the type of the editing contol that DateTimePickerCell uses.
                    return typeof(DateTimePickerEditingControl);
                }
            }

            public override Type ValueType
            {
                get
                {
                    // Return the type of the value that DateTimePickerCell contains.
                    return typeof(DateTime);
                }
            }

            public override object DefaultNewRowValue
            {
                get
                {
                    //Return null as the default value for new row.
                    return null;
                }
            }
        }

        class DateTimePickerEditingControl : DateTimePicker, IDataGridViewEditingControl
        {
            DataGridView dataGridView;
            private bool valueChanged = false;
            int rowIndex;

            public DateTimePickerEditingControl()
            {
                this.Format = DateTimePickerFormat.Custom;
                this.CustomFormat = "dd.MM.yyyy";
          //      this.ShowCheckBox = true;
              //  this.Checked = false;
            }

            // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
            // property.
            public object EditingControlFormattedValue
            {
                get
                {
                    return this.Value.ToShortDateString();
                }
                set
                {
                    if (value is String)
                    {
                        this.Value = DateTime.Parse((String)value);
                    }
                }
            }

            // Implements the 
            // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
            public object GetEditingControlFormattedValue(
                DataGridViewDataErrorContexts context)
            {
                return EditingControlFormattedValue;
            }

            // Implements the 
            // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
            public void ApplyCellStyleToEditingControl(
                DataGridViewCellStyle dataGridViewCellStyle)
            {
                this.Font = dataGridViewCellStyle.Font;
                this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
                this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
            }

            // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
            // property.
            public int EditingControlRowIndex
            {
                get
                {
                    return rowIndex;
                }
                set
                {
                    rowIndex = value;
                }
            }

            // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
            // method.
            public bool EditingControlWantsInputKey(
                Keys key, bool dataGridViewWantsInputKey)
            {
                // Let the DateTimePicker handle the keys listed.
                switch (key & Keys.KeyCode)
                {
                    case Keys.Left:
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Right:
                    case Keys.Home:
                    case Keys.End:
                    case Keys.PageDown:
                    case Keys.PageUp:
                        return true;
                    default:
                        return !dataGridViewWantsInputKey;
                }
            }

            // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
            // method.
            public void PrepareEditingControlForEdit(bool selectAll)
            {
                // No preparation needs to be done.
            }

            // Implements the IDataGridViewEditingControl
            // .RepositionEditingControlOnValueChange property.
            public bool RepositionEditingControlOnValueChange
            {
                get
                {
                    return false;
                }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingControlDataGridView property.
            public DataGridView EditingControlDataGridView
            {
                get
                {
                    return dataGridView;
                }
                set
                {
                    dataGridView = value;
                }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingControlValueChanged property.
            public bool EditingControlValueChanged
            {
                get
                {
                    return valueChanged;
                }
                set
                {
                    valueChanged = value;
                }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingPanelCursor property.
            public Cursor EditingPanelCursor
            {
                get
                {
                    return base.Cursor;
                }
            }

            protected override void OnValueChanged(EventArgs eventargs)
            {
                // Notify the DataGridView that the contents of the cell
                // have changed.
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnValueChanged(eventargs);
            }
        }



    }
}
