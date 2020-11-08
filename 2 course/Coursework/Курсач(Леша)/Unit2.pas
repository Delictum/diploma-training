unit Unit2;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.FMTBcd, DBXMySQL, Data.DB,
  Data.SqlExpr, Datasnap.Provider, Datasnap.DBClient, Vcl.StdCtrls,
  Vcl.Imaging.jpeg, Vcl.ExtCtrls, Vcl.Menus, ShellAPI, Vcl.Imaging.pngimage;

type
  TLogReg = class(TForm)
    EditNameLog: TEdit;
    EditPasLog: TEdit;
    EditRPasLog: TEdit;
    BtnReg: TButton;
    DataSource1: TDataSource;
    ClientDataSet1: TClientDataSet;
    DataSetProvider1: TDataSetProvider;
    SQLQuery1: TSQLQuery;
    SQLConnection1: TSQLConnection;
    BtnBack: TButton;
    Image1: TImage;
    MainMenu1: TMainMenu;
    N1: TMenuItem;
    N4: TMenuItem;
    Helper1: TMenuItem;
    procedure BtnRegClick(Sender: TObject);
    procedure EditNameLogClick(Sender: TObject);
    procedure EditPasLogClick(Sender: TObject);
    procedure EditRPasLogClick(Sender: TObject);
    procedure BtnBackClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Helper1Click(Sender: TObject);
    procedure N4Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  LogReg: TLogReg;
  EPRLClick1, EPLClick1, ENLClick1 : boolean;

implementation

{$R *.dfm}

uses Unit1, Unit4, Unit3;

procedure TLogReg.BtnBackClick(Sender: TObject);
begin
  LogReg.Hide;
  LogOut.Show;
  EditRPasLog.Visible := true;
end;

procedure TLogReg.BtnRegClick(Sender: TObject);
Var bufName1, bufPas1, bufID : string;
    ID : integer;
begin
  if BtnReg.Caption = '������������������' then
    begin
      if (EditNameLog.Text = '') or (EditNameLog.Text = '������� ������������') then
        begin
          ShowMessage('������� ������ ������������.');
          exit;
        end;
      if (EditPasLog.Text = '') or (EditPasLog.Text = '������� ������') then
        begin
          ShowMessage('������� ������.');
          exit;
        end;
      if (EditRPasLog.Text = '') or (EditRPasLog.Text = '��������� ������') then
        begin
          ShowMessage('��������� ������.');
          exit;
        end;
      ClientDataSet1.Active := false;
       SQLQuery1.Close;
        SQLQuery1.SQL.Clear;
         SQLQuery1.SQL.Add('SELECT Name FROM Users WHERE Name = "' + EditNameLog.Text + '"');
          SQLQuery1.Open;
           ClientDataSet1.Active := true;
      bufName1 := VarToStr(SQLQuery1.FieldValues['Name']);
      if bufName1 = EditNameLog.Text then
        begin
          ShowMessage('������������ ��� ����������.');
          exit;
        end;
      if EditRPasLog.Text <> EditPasLog.Text then
        begin
          ShowMessage('������ �� ���������.');
          exit;
        end;
      ClientDataSet1.Active := false;
        SQLQuery1.Close;
         SQLQuery1.SQL.Clear;
          SQLQuery1.SQL.Add('SELECT MAX(ID) AS ID FROM Users');
           SQLQuery1.Open;
            ClientDataSet1.Active := true;
      BufID := IntToStr(SQLQuery1.FieldValues['ID']);
      ID := StrToInt(BufID) + 1;
      SQLQuery1.Close;
       SQLQuery1.SQL.Clear;
        SQLQuery1.SQL.Add('INSERT INTO Users(ID, Name, Password) VALUES (');
         SQLQuery1.SQL.Add(IntToStr(ID) + ', "' + EditNameLog.Text + '", "' + EditPasLog.Text + '")');
          SQLQuery1.ExecSQL;
      ClientDataSet1.Active := false;
       SQLQuery1.Close;
        SQLQuery1.SQL.Clear;
         SQLQuery1.SQL.Add('SELECT * FROM Users');
          SQLQuery1.Open;
           ClientDataSet1.Active := true;
      ShowMessage('������������ ������� ��������.');
    end;

  if BtnReg.Caption = '��������' then
    begin
      if (EditNameLog.Text = '') or (EditNameLog.Text = '������� ������������') then
        begin
          ShowMessage('������� ������ ������������.');
          exit;
        end;
      if (EditPasLog.Text = '') or (EditPasLog.Text = '������� ������') then
        begin
          ShowMessage('������� ����� ������.');
          exit;
        end;
      ClientDataSet1.Active := false;
       SQLQuery1.Close;
        SQLQuery1.SQL.Clear;
         SQLQuery1.SQL.Add('SELECT Name FROM Users WHERE Name = "' + EditNameLog.Text + '"');
          SQLQuery1.Open;
           ClientDataSet1.Active := true;
      bufName1 := VarToStr(SQLQuery1.FieldValues['Name']);
      if bufName <> bufName1 then
        if bufName1 = EditNameLog.Text then
          begin
            ShowMessage('������������ ��� ����������.');
            exit;
          end;
      SQLQuery1.Close;
       SQLQuery1.SQL.Clear;
        SQLQuery1.SQL.Add('UPDATE Users Set Name = "' + EditNameLog.Text + '", Password = "' + EditPasLog.Text + '" ');
         SQLQuery1.SQL.Add('WHERE Name = "' + bufName + '" AND Password = "' + bufPas + '"');
          SQLQuery1.ExecSQL;
      ClientDataSet1.Active := false;
       SQLQuery1.Close;
        SQLQuery1.SQL.Clear;
         SQLQuery1.SQL.Add('SELECT * FROM Users');
          SQLQuery1.Open;
           ClientDataSet1.Active := true;
      ShowMessage('������������ ������� �������.');
    end;

  if BtnReg.Caption = '�������' then
    begin
      if (EditPasLog.Text = '') or (EditPasLog.Text = '������� ������') then
        begin
          ShowMessage('����������� ������.');
          exit;
        end;
      SQLQuery1.Close;
       SQLQuery1.SQL.Clear;
        SQLQuery1.SQL.Add('DELETE FROM Users WHERE Name = "' + bufName + '"');
         SQLQuery1.ExecSQL;
      ClientDataSet1.Active := false;
       SQLQuery1.Close;
        SQLQuery1.SQL.Clear;
         SQLQuery1.SQL.Add('SELECT * FROM Users');
          SQLQuery1.Open;
           ClientDataSet1.Active := true;
      ShowMessage('������������ ������� ������.');
    end;
end;

procedure TLogReg.EditNameLogClick(Sender: TObject);
begin
if ENLClick1 <> true then
    EditNameLog.Text := '';
  ENLClick1 := true;
end;

procedure TLogReg.EditPasLogClick(Sender: TObject);
begin
  if EPLClick1 <> true then
    begin
      EditPasLog.Text := '';
      EditPasLog.PasswordChar := '*';
    end;
  EPLClick1 := true;
end;

procedure TLogReg.EditRPasLogClick(Sender: TObject);
begin
  if EPRLClick1 <> true then
    begin
      EditRPasLog.Text := '';
      EditRPasLog.PasswordChar := '*';
    end;
  EPRLClick1 := true;
end;

procedure TLogReg.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  FormDinozavr.Close;
  LogOut.Close;
end;

procedure TLogReg.Helper1Click(Sender: TObject);
begin
  ShellExecute (LogReg.Handle, nil, 'iexplore', 'https://minenco1998.wixsite.com/mysite', nil, SW_RESTORE);
end;

procedure TLogReg.N4Click(Sender: TObject);
begin
  LogOut.Close;
  LogReg.Close;
  FormDinozavr.Close;
end;

end.
