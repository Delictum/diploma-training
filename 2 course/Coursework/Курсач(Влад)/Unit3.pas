unit Unit3;

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
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    procedure EditNameLogClick(Sender: TObject);
    procedure EditPasLogClick(Sender: TObject);
    procedure BtnLEDClick(Sender: TObject);
    procedure Helper1Click(Sender: TObject);
    procedure N4Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  LogOut: TLogOut;
  ENLClick, EPLClick, LogRegShow : boolean;
  bufName, bufPas : string;

implementation

{$R *.dfm}

uses Unit2, Unit5, Unit6, Unit10, Unit11;

{������� �� ������ "����". ������������ �������� ������������ � ���� ������ ������� Users.
��� ������ ������ ������� �� ����.}
procedure TLogOut.BtnLEDClick(Sender: TObject);
begin
  if (EditNameLog.Text = 'Admin') and (EditNameLog.Text = 'Admin') then
    begin
      LogOut.Hide;
      FormAdmin.Show;
      FormBegin.Button1.Visible := true;
      exit;
    end;
//�������� ����� ������������.
  if (EditNameLog.Text = '') or (EditNameLog.Text = '������� ������������') then
    begin
      ShowMessage('������� ������������.');
      exit;
    end;
//�������� ����� ������.
  if (EditPasLog.Text = '') or (EditPasLog.Text = '������� ������') then
    begin
      ShowMessage('������� ������.');
      exit;
    end;
//����� ���������� ������������ � ���� ������ ������� Users.
  ClientDataSet1.Active := false;
   SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
     SQLQuery1.SQL.Add('SELECT Name FROM Users WHERE Name = "' + EditNameLog.Text + '"');
      SQLQuery1.Open;
       ClientDataSet1.Active := true;
  bufName := '';
  bufName := VarToStr(SQLQuery1.FieldValues['Name']);
//�� ������ - �����.
  if bufName <> EditNameLog.Text then
    begin
      ShowMessage('������������ �� ����������.');
      exit;
    end;
//��������� ������ ������������.
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT Password FROM Users WHERE Password = "' + EditPasLog.Text + '"');
  //SQLQuery1.SQL.Add('" AND Name = "' + EditNameLog.Text + '"');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;
  bufPas := '';
  bufPas := VarToStr(SQLQuery1.FieldValues['Password']);
  if bufPas <> EditPasLog.Text then
//�� ������ - �����.
    begin
      ShowMessage('�������� ������.');
      exit;
    end;
//������� ���� �������������
  ClientDataSet1.Active := false;
   SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
     SQLQuery1.SQL.Add('SELECT * FROM Users');
      SQLQuery1.Open;
       ClientDataSet1.Active := true;
  LogOut.Hide;
  FormBegin.Show;
  Otvet := 0;
end;

procedure TLogOut.Button1Click(Sender: TObject);
begin
 //�����������
  LogOut.Hide;
  LogReg.Show;
  LogReg.BtnReg.Caption := '������������������';
  LogReg.EditRPasLog.Visible := true;
  LogReg.EditNameLog.Visible := true;
  LogReg.EditPasLog.Visible := true;
  LogReg.Caption := '���������� ������������';
end;

procedure TLogOut.Button2Click(Sender: TObject);
begin
  if (EditNameLog.Text = '') or (EditNameLog.Text = '������� ������������') then
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

procedure TLogOut.Button3Click(Sender: TObject);
begin
  if (EditNameLog.Text = '') or (EditNameLog.Text = '������� ������������') then
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

procedure TLogOut.Button4Click(Sender: TObject);
begin
  ShellExecute (LogOut.Handle, nil, 'iexplore', 'https://thedrakoneragoni.wixsite.com/helper/', nil, SW_RESTORE);
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
begin
  Form10.Close;
end;

procedure TLogOut.Helper1Click(Sender: TObject);
begin
  ShellExecute (LogOut.Handle, nil, 'iexplore', 'www.thedrakoneragoni.wix.com/helper/', nil, SW_RESTORE);
end;

procedure TLogOut.N4Click(Sender: TObject);
  Var i : integer;
begin
  LogOut.Close;
end;

end.
