unit Unit6;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Data.DBXMySQL,
  Data.FMTBcd, Data.DB, Datasnap.Provider, Datasnap.DBClient, Data.SqlExpr;

type
  TForm6 = class(TForm)
    EditNameLog: TEdit;
    EditPasLog: TEdit;
    EditRPasLog: TEdit;
    BtnReg: TButton;
    BtnBack: TButton;
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    ClientDataSet1: TClientDataSet;
    DataSetProvider1: TDataSetProvider;
    DataSource1: TDataSource;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    procedure BtnRegClick(Sender: TObject);
    procedure BtnBackClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form6: TForm6;

implementation

{$R *.dfm}

uses Unit4;

procedure TForm6.BtnBackClick(Sender: TObject);
begin
  Form6.Hide;
  Form4.Show;
end;

procedure TForm6.BtnRegClick(Sender: TObject);
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

procedure TForm6.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  Form4.Close;
end;

end.
