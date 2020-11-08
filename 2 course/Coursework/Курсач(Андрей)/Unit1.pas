unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, DBXMySQL, Data.FMTBcd, Data.DB,
  Vcl.Grids, Vcl.DBGrids, Datasnap.Provider, Datasnap.DBClient, Data.SqlExpr,
  Vcl.StdCtrls, jpeg, Vcl.ExtCtrls, Vcl.Menus, ShellAPI, Vcl.Imaging.pngimage;

type
  TLogOut = class(TForm)
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    DataSource1: TDataSource;
    EditNameLog: TEdit;
    EditPasLog: TEdit;
    BtnLED: TButton;
    CBUsers: TComboBox;
    Image1: TImage;
    MainMenu1: TMainMenu;
    N1: TMenuItem;
    N4: TMenuItem;
    Helper1: TMenuItem;
    procedure EditNameLogClick(Sender: TObject);
    procedure EditPasLogClick(Sender: TObject);
    procedure BtnLEDClick(Sender: TObject);
    procedure CBUsersChange(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Helper1Click(Sender: TObject);
    procedure N2Click(Sender: TObject);
    procedure N4Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  LogOut: TLogOut;
  ENLClick, EPLClick, LogRegShow : boolean;
  bufName, bufPas : string;
  Admin : integer;

implementation

{$R *.dfm}

uses Unit2, Unit3, Unit4, Unit5, Unit7, Unit10, Unit8;

procedure TLogOut.BtnLEDClick(Sender: TObject);
begin
  if (EditNameLog.Text = 'Admin') and (EditPasLog.Text = 'Admin') then
    begin
      LogOut.Hide;
      FormADMIN.Show;
      FormBegin.Button1.Visible := true;
      FormBegin.Button2.Visible := true;
      exit;
    end;
  if (EditNameLog.Text = '') or (EditNameLog.Text = '������� ������������') then
    begin
      ShowMessage('������� ������������.');
      exit;
    end;
  if (EditPasLog.Text = '') or (EditPasLog.Text = '������� ������') then
    begin
      ShowMessage('������� ������.');
      exit;
    end;
  ClientDataSet1.Active := false;
   SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
     SQLQuery1.SQL.Add('SELECT Name FROM Users WHERE Name = "' + EditNameLog.Text + '"');
      SQLQuery1.Open;
       ClientDataSet1.Active := true;
  bufName := VarToStr(SQLQuery1.FieldValues['Name']);
  if bufName <> EditNameLog.Text then
    begin
      ShowMessage('������������ �� ����������.');
      exit;
    end;
  ClientDataSet1.Active := false;
   SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
     SQLQuery1.SQL.Add('SELECT Password FROM Users WHERE Password = "' + EditPasLog.Text + '"');
      SQLQuery1.Open;
       ClientDataSet1.Active := true;
  bufPas := VarToStr(SQLQuery1.FieldValues['Password']);
  if bufPas <> EditPasLog.Text then
    begin
      ShowMessage('�������� ������.');
      exit;
    end;
  ClientDataSet1.Active := false;
   SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
     SQLQuery1.SQL.Add('SELECT * FROM Users');
      SQLQuery1.Open;
       ClientDataSet1.Active := true;
  if bufName = 'Admin' then Admin := 1;
  GameScore := 0;
  LogOut.Hide;
  FormBegin.Show;
end;

procedure TLogOut.CBUsersChange(Sender: TObject);
begin
  case CBUsers.ItemIndex of
    0:
      begin
        LogOut.Hide;
        LogReg.Show;
        LogReg.BtnReg.Caption := '������������������';
        LogReg.EditRPasLog.Visible := true;
        LogReg.Caption := '���������� ������������';
      end;
    1:
      begin
        if (EditNameLog.Text = '') or (EditNameLog.Text = '������� ������������') or (EditNameLog.Text = 'Admin') then
          begin
            ShowMessage('������� ����������� ������������.');
            exit;
          end;
        if (EditPasLog.Text = '') or (EditPasLog.Text = '������� ������') then
          begin
            ShowMessage('������� ������.');
            exit;
          end;
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT Name FROM Users WHERE Name = "' + EditNameLog.Text + '"');
            SQLQuery1.Open;
             ClientDataSet1.Active := true;
        bufName := VarToStr(SQLQuery1.FieldValues['Name']);
        if bufName <> EditNameLog.Text then
          begin
            ShowMessage('������������ �� ����������.');
            exit;
          end;
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT Password FROM Users WHERE Password = "' + EditPasLog.Text + '"');
            SQLQuery1.Open;
             ClientDataSet1.Active := true;
        bufPas := VarToStr(SQLQuery1.FieldValues['Password']);
        if bufPas <> EditPasLog.Text then
          begin
            ShowMessage('�������� ������.');
            exit;
          end;
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT * FROM Users');
            SQLQuery1.Open;
             ClientDataSet1.Active := true;

        LogOut.Hide;
        LogReg.Show;
        LogReg.BtnReg.Caption := '��������';
        LogReg.EditRPasLog.Visible := false;
        LogReg.Caption := '�������������� ������������';
      end;
    2:
      begin
        if (EditNameLog.Text = '') or (EditNameLog.Text = '������� ������������') or (EditNameLog.Text = 'Admin') then
          begin
            ShowMessage('������� ���������� ������������.');
            exit;
          end;
        if (EditPasLog.Text = '') or (EditPasLog.Text = '������� ������') then
          begin
            ShowMessage('������� ������.');
            exit;
          end;
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT Name FROM Users WHERE Name = "' + EditNameLog.Text + '"');
            SQLQuery1.Open;
             ClientDataSet1.Active := true;
        bufName := VarToStr(SQLQuery1.FieldValues['Name']);
        if bufName <> EditNameLog.Text then
          begin
            ShowMessage('������������ �� ����������.');
            exit;
          end;
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT Password FROM Users WHERE Password = "' + EditPasLog.Text + '"');
            SQLQuery1.Open;
             ClientDataSet1.Active := true;
        bufPas := VarToStr(SQLQuery1.FieldValues['Password']);
        if bufPas <> EditPasLog.Text then
          begin
            ShowMessage('�������� ������.');
            exit;
          end;
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
           SQLQuery1.SQL.Add('SELECT * FROM Users');
            SQLQuery1.Open;
             ClientDataSet1.Active := true;

        LogOut.Hide;
        LogReg.Show;
        LogReg.BtnReg.Caption := '�������';
        LogReg.EditRPasLog.Visible := false;
        LogReg.EditNameLog.Visible := false;
        LogReg.Caption := '�������� ������������';
      end;
  end;
end;

procedure TLogOut.EditNameLogClick(Sender: TObject);
begin
  if ENLClick <> true then
    EditNameLog.Text := '';
  ENLClick := true;
end;

procedure TLogOut.EditPasLogClick(Sender: TObject);
begin
  if EPLClick <> true then
    begin
      EditPasLog.Text := '';
      EditPasLog.PasswordChar := '*';
    end;
  EPLClick := true;
end;

procedure TLogOut.FormClose(Sender: TObject; var Action: TCloseAction);
  Var i : integer;
begin
  for i := 1 to 10 do
    if FileExists('music\' + IntToStr(i) +'.mp3') then
      DeleteFile('music\' + IntToStr(i) +'.mp3');
  Form10.Close;
end;

procedure TLogOut.Helper1Click(Sender: TObject);
begin
  FormHelp.Show;
end;

procedure TLogOut.N2Click(Sender: TObject);
  Var i : integer;
begin
  for i := 1 to 10 do
    if FileExists('music\' + IntToStr(i) +'.mp3') then
      DeleteFile('music\' + IntToStr(i) +'.mp3');
  FormGame.Hide;
  LogOut.Show;
end;

procedure TLogOut.N4Click(Sender: TObject);
  Var i : integer;
begin
  for i := 1 to 10 do
    if FileExists('music\' + IntToStr(i) +'.mp3') then
      DeleteFile('music\' + IntToStr(i) +'.mp3');
  LogOut.Close;
end;

end.
