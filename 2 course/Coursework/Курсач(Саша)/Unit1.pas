unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, DBXMySQL, Data.FMTBcd, Data.DB,
  Vcl.StdCtrls, Vcl.DBCtrls, Vcl.Grids, Vcl.DBGrids, Datasnap.DBClient,
  Datasnap.Provider, Data.SqlExpr, ShellAPI;

type
  TFormMain = class(TForm)
    SQLConnection1: TSQLConnection;
    DBMemo1: TDBMemo;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    DataSource1: TDataSource;
    ClientDataSet1: TClientDataSet;
    Button4: TButton;
    Button6: TButton;
    DBGrid1: TDBGrid;
    SQLQuery2: TSQLQuery;
    DataSetProvider2: TDataSetProvider;
    ClientDataSet2: TClientDataSet;
    DataSource2: TDataSource;
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormMain: TFormMain;

implementation

{$R *.dfm}

uses Unit2, Unit10;

procedure TFormMain.Button1Click(Sender: TObject);
begin
  Form2.Show;
  Form2.Caption := '����������';
  Form2.Button1.Caption := '��������';
  Form2.DBComboBox1.Visible := false;
  Form2.EditHoliday.Visible := false;
  Form2.EditMonth.Visible := false;
  Form2.EditDay.Visible := false;
  Form2.Memo1.Visible := false;
  Form2.EditMonth.DataSource := nil;
  Form2.EditDay.DataSource := nil;
  Form2.EditHoliday.DataSource := nil;
  Form2.Memo1.DataSource := nil;
end;

procedure TFormMain.Button2Click(Sender: TObject);
begin
  Form2.Show;
  Form2.Caption := '��������������';
  Form2.Button1.Caption := '�������������';
  Form2.DBComboBox1.Visible := false;
  Form2.EditHoliday.Visible := true;
  Form2.EditMonth.Visible := true;
  Form2.EditDay.Visible := true;
  Form2.Memo1.Visible := true;
  Form2.EditMonth.DataSource := FormMain.DataSource1;
  Form2.EditDay.DataSource := FormMain.DataSource1;
  Form2.EditHoliday.DataSource := FormMain.DataSource1;
  Form2.Memo1.DataSource := FormMain.DataSource1;
end;

procedure TFormMain.Button3Click(Sender: TObject);
begin
  Form2.Show;
  Form2.Caption := '��������';
  Form2.Button1.Caption := '�������';
  Form2.DBComboBox1.Visible := true;
  Form2.EditHoliday.Visible := true;
  Form2.EditMonth.Visible := true;
  Form2.EditDay.Visible := true;
  Form2.Memo1.Visible := true;
  Form2.EditMonth.DataSource := FormMain.DataSource1;
  Form2.EditDay.DataSource := FormMain.DataSource1;
  Form2.EditHoliday.DataSource := FormMain.DataSource1;
  Form2.Memo1.DataSource := FormMain.DataSource1;
end;

procedure TFormMain.Button4Click(Sender: TObject);
begin
  ShellExecute(FormMain.Handle, nil, 'iexplore', 'www.thedrakoneragoni.wix.com/helper/', nil, SW_RESTORE);
end;

procedure TFormMain.Button6Click(Sender: TObject);
begin
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT Date.ID, Holiday.ID, People.Name, Description, Holiday.Name, Month, Day FROM Holiday, Date, People WHERE ID_Date=Date.ID AND ID_People=People.ID');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;

  DBGrid1.Refresh;
end;

procedure TFormMain.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  Form10.Close;
end;

end.
