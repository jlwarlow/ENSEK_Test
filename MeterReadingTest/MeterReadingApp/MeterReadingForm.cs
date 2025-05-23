using MeterReadingApp.Client;
using System.Text;

namespace MeterReadingApp;

public partial class MeterReadingForm : Form
{
    private IMeterReadingClient _client;

    public MeterReadingForm()
    {
        _client = new MeterReadingClient();
        InitializeComponent();
    }

    private void LoadCSVButton_Click(object sender, EventArgs e)
    {
        Stream? fileStream = null;

        // Show file load dialog
        var openDialog = new OpenFileDialog
        {
            Filter = "CSV Files (*.csv)|*.csv",
            Title = "Select a CSV file"
        };

        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                if ((fileStream = openDialog.OpenFile()) != null)
                {
                    using (fileStream)
                    {
                        using var streamReader = new StreamReader(fileStream);
                        var csv = streamReader.ReadToEnd();
                        if (string.IsNullOrEmpty(csv))
                        {
                            MessageBox.Show($"Error: Empty file selected : {openDialog.FileName}");
                        }
                        else
                        {
                            richTextBox.Text = csv;
                            ProcessButton.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: Could not read file from disk. Original error: {ex.Message}");
            }
        }
    }

    private async void ProcessButton_Click(object sender, EventArgs e)
    {
        var csvData = Encoding.ASCII.GetBytes(richTextBox.Text);
        UseWaitCursor = true;
        var result = await _client.PostMeterReadings(csvData);
        UseWaitCursor = false;

        if (result != null)
        {
            MessageBox.Show($"{result.TotalRecords} Total Records, {result.FailedRecords} failed records.");
        }
    }
}
