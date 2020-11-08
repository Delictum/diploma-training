unit Unit4;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DBXMySQL, Data.FMTBcd, Data.DB,
  Datasnap.Provider, Datasnap.DBClient, Data.SqlExpr, Vcl.StdCtrls;

type
  TForm4 = class(TForm)
    EditNameLog: TEdit;
    EditPasLog: TEdit;
    BtnLED: TButton;
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    ClientDataSet1: TClientDataSet;
    DataSetProvider1: TDataSetProvider;
    DataSource1: TDataSource;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Label1: TLabel;
    Label2: TLabel;
    procedure BtnLEDClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form4: TForm4;
  bufName, bufPas : string;

implementation

{$R *.dfm}

uses Unit10, Unit1, Unit5, Unit6;

procedure TForm4.BtnLEDClick(Sender: TObject);
begin
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
  if (EditNameLog.Text = 'Admin') and(EditPasLog.Text = 'Admin') then
  begin
    Form4.Hide;
    Form5.Show;
    FormProg.Button3.Visible := true;
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
  Form4.Hide;
  FormProg.Show;
end;

procedure TForm4.Button1Click(Sender: TObject);
begin
  Form4.Hide;
  Form6.Show;
  Form6.BtnReg.Caption := '������������������';
  Form6.EditRPasLog.Visible := true;
  Form6.Caption := '���������� ������������';
end;

procedure TForm4.Button2Click(Sender: TObject);
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

  Form4.Hide;
  Form6.Show;
  Form6.BtnReg.Caption := '��������';
  Form6.EditRPasLog.Visible := true;
  Form6.Caption := '�������������� ������������';
end;

procedure TForm4.Button3Click(Sender: TObject);
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

  Form4.Hide;
  Form6.Show;
  Form6.BtnReg.Caption := '�������';
  Form6.EditRPasLog.Visible := true;
  Form6.Caption := '�������� ������������';
end;

procedure TForm4.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  Form10.Close;
end;

end.
