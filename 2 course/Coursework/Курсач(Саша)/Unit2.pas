unit Unit2;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.FMTBcd, Data.DB, Datasnap.DBClient,
  Datasnap.Provider, Data.SqlExpr, Vcl.StdCtrls, Vcl.DBCtrls, Vcl.Mask;

type
  TForm2 = class(TForm)
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    DataSource1: TDataSource;
    SQLQuery2: TSQLQuery;
    DataSetProvider2: TDataSetProvider;
    ClientDataSet2: TClientDataSet;
    DataSource2: TDataSource;
    DBLCBPeople: TDBLookupComboBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Button1: TButton;
    DBEdit1: TDBEdit;
    DBEdit2: TDBEdit;
    DBEdit3: TDBEdit;
    EditMonth: TDBEdit;
    EditDay: TDBEdit;
    EditHoliday: TDBEdit;
    Memo1: TDBMemo;
    DBComboBox1: TDBComboBox;
    Memo2: TMemo;
    EditHoliday2: TEdit;
    EditMonth2: TEdit;
    EditDay2: TEdit;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;

implementation

{$R *.dfm}

uses Unit1;

procedure TForm2.Button1Click(Sender: TObject);
Var i, BufDateID, BufHolidayID, BufEventID, BufEventDateID : integer;
    BufDateStr, BufPeopleStr, BufHolidayStr, BufEventStr : string;
begin
  if Button1.Caption = '��������' then
    begin
      if EditMonth2.Text = '' then
        exit;
      if EditDay2.Text = '' then
        exit;
      if EditHoliday2.Text = '' then
        exit;
      if DBLCBPeople.Text = '' then
        exit;
      if Memo2.Text = '' then
        exit;

      BufDateID := 0;
      BufDateStr := '';
      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('SELECT MAX(ID) AS ID FROM Date');
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      BufDateStr := IntToStr(SQLQuery1.FieldValues['ID']);
      BufDateID := StrToInt(BufDateStr) + 1;

      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('INSERT INTO Date (ID, Month, Day) VALUES(');
      SQLQuery1.SQL.Add(IntToStr(BufDateID) + ', ' + EditMonth2.Text + ', ' + EditDay2.Text + ')');
      SQLQuery1.ExecSQL;

      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('SELECT ID FROM People WHERE Name = "' + DBLCBPeople.Text + '"');
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      BufPeopleStr := VarToStr(SQLQuery1.FieldValues['ID']);

      BufHolidayID := 0;
      BufHolidayStr := '';
      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('SELECT MAX(ID) AS ID FROM Holiday');
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      BufHolidayStr := IntToStr(SQLQuery1.FieldValues['ID']);
      BufHolidayID := StrToInt(BufHolidayStr) + 1;

      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('INSERT INTO Holiday (ID, Name, Description, ID_People, ID_Date) VALUES(');
      SQLQuery1.SQL.Add(IntToStr(BufHolidayID) + ', "' + EditHoliday2.Text + '", "');
      for I := 0 to Memo1.Lines.Count do
        SQLQuery1.SQL.Add(Memo2.Lines[i]);
      SQLQuery1.SQL.Add('", ' + BufPeopleStr + ', ' + IntToStr(BufDateID) + ')');
      SQLQuery1.ExecSQL;

      ShowMessage('���������!!!');
      exit;
    end;
  if Button1.Caption = '�������' then
    begin
      BufHolidayStr := '';
      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('SELECT ID FROM Holiday WHERE Name = "' + EditHoliday.Text + '"');
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      BufHolidayStr := VarToStr(SQLQuery1.FieldValues['ID']);

      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('DELETE FROM Date WHERE Day = ' + EditDay.Text + ' AND ');
      SQLQuery1.SQL.Add('Month = ' + EditMonth.Text);
      SQLQuery1.ExecSQL;

      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('DELETE FROM Holiday WHERE ID = ' + DBEdit3.Text);
      SQLQuery1.ExecSQL;

      ShowMessage('�������!!!');
      exit;
    end;
  if Button1.Caption = '�������������' then
    begin
      if EditMonth.Text = '' then
        exit;
      if EditDay.Text = '' then
        exit;
      if EditHoliday.Text = '' then
        exit;
      if DBLCBPeople.Text = '' then
        exit;
      if Memo1.Text = '' then
        exit;

      BufDateStr := '';
      BufDateStr := DBEdit1.Text;

      //ShowMessage('UPDATE Date SET Day = ' + EditDay.Text + ', Month = ' + EditMonth.Text + ' WHERE ID = ' + BufDateStr);

      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('UPDATE Date SET Day = ' + EditDay.Text + ', Month = ' + EditMonth.Text);
      SQLQuery1.SQL.Add(' WHERE ID = ' + BufDateStr);
      SQLQuery1.ExecSQL;

      //ShowMessage('SELECT ID FROM People WHERE Name = "' + DBLCBPeople.Text + '"');

      BufPeopleStr := '';
      ClientDataSet1.Active := false;
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('SELECT ID FROM People WHERE Name = "' + DBLCBPeople.Text + '"');
      SQLQuery1.Open;
      ClientDataSet1.Active := true;
      BufPeopleStr := VarToStr(SQLQuery1.FieldValues['ID']);

      BufHolidayStr := '';
      BufHolidayStr := DBEdit2.Text;

      //ShowMessage('UPDATE Holiday SET Name = "' + EditDay.Text + '", Description = "123", ID_People = ' + BufPeopleStr + ', ID_Date = ' + BufDateStr + ' WHERE ID = ' + BufHolidayStr);

      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('UPDATE Holiday SET Name = "' + EditHoliday.Text + '", Description = "');
      for I := 0 to Memo1.Lines.Count do
        SQLQuery1.SQL.Add(Memo1.Lines[i]);
      SQLQuery1.SQL.Add('", ID_People = ' + BufPeopleStr + ', ID_Date = ' + BufDateStr + ' WHERE ID = ' + BufHolidayStr);
      SQLQuery1.ExecSQL;

      ShowMessage('���������������!!!');
      exit;
    end;
end;

end.
