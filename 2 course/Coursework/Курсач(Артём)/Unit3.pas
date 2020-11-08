unit Unit3;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Mask, Vcl.DBCtrls,
  Vcl.ExtCtrls, Data.FMTBcd, Data.DB, Datasnap.DBClient, Datasnap.Provider,
  Data.SqlExpr, DateUtils, Vcl.ComCtrls;

type
  TFormAED = class(TForm)
    DBEditAirline: TDBEdit;
    DBEditAircraftName: TDBEdit;
    PanelAirline: TPanel;
    PanelAircraft: TPanel;
    DBEditAircraftEnginesType: TDBEdit;
    LabelNamePanelAircraft: TLabel;
    LabelNamePanelAirline: TLabel;
    LabelNameAirline: TLabel;
    EditAirline: TEdit;
    LabelNameAirlineNow: TLabel;
    LabelNameAirlineNew: TLabel;
    EditAircraftName: TEdit;
    LabelNameAircraftNew: TLabel;
    LabelNameAircraftNow: TLabel;
    LabelNameAircraft: TLabel;
    LabelEnginesTypeAircraft: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    EditAircraftEnginesType: TEdit;
    Bevel1: TBevel;
    Bevel2: TBevel;
    EditAircraftVelocity: TEdit;
    Label4: TLabel;
    Label5: TLabel;
    DBEditAircraftVelocity: TDBEdit;
    Label6: TLabel;
    Bevel3: TBevel;
    Label1: TLabel;
    Label7: TLabel;
    DBEditAircraftCapacity: TDBEdit;
    Label8: TLabel;
    EditAircraftCapacity: TEdit;
    Bevel4: TBevel;
    Label9: TLabel;
    DBEditAirlineID: TDBEdit;
    Label10: TLabel;
    EditAircraftAirlineID: TEdit;
    DBEditAircraftAirlineID: TDBEdit;
    Label11: TLabel;
    Label12: TLabel;
    DBEditAircraftID: TDBEdit;
    Label13: TLabel;
    Bevel5: TBevel;
    BtnAirlineAdd: TButton;
    BtnAirlineDel: TButton;
    BtnAirlineEdd: TButton;
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    DataSource1: TDataSource;
    BtnAircraftAdd: TButton;
    BtnAircraftDel: TButton;
    BtnAircraftEdd: TButton;
    BtnAircraftDelNow: TButton;
    PanelFlights: TPanel;
    Label14: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    Label17: TLabel;
    Label18: TLabel;
    Label19: TLabel;
    Label20: TLabel;
    Bevel6: TBevel;
    Bevel7: TBevel;
    Label21: TLabel;
    Label22: TLabel;
    Label23: TLabel;
    Bevel8: TBevel;
    Label24: TLabel;
    Label25: TLabel;
    Label26: TLabel;
    Bevel9: TBevel;
    Label27: TLabel;
    Label28: TLabel;
    Label29: TLabel;
    Label30: TLabel;
    Bevel10: TBevel;
    DBEditFlightsDepartureTime: TDBEdit;
    DBEditFlightsAircraftID: TDBEdit;
    EditFlightsAircraftID: TEdit;
    DBEditFlightsArrivalTime: TDBEdit;
    DBEditFlightsDeparturePoint: TDBEdit;
    EditFlightsDeparturePoint: TEdit;
    EditFlightsArrivalPoint: TEdit;
    DBEditFlightsArrivalPoint: TDBEdit;
    DBEditFlightsID: TDBEdit;
    BtnFlightsAdd: TButton;
    BtnFlightsEdd: TButton;
    BtnFlightsDelNow: TButton;
    Bevel11: TBevel;
    Bevel12: TBevel;
    Label31: TLabel;
    Label32: TLabel;
    Label33: TLabel;
    DBLookupComboBoxFlightsStatusID: TDBLookupComboBox;
    SQLQuery2: TSQLQuery;
    DataSetProvider2: TDataSetProvider;
    ClientDataSet2: TClientDataSet;
    DataSource2: TDataSource;
    DBComboBoxFlightsStatusID: TDBComboBox;
    EditFlightsDepartureTime: TEdit;
    EditFlightsArrivalTime: TEdit;
    procedure BtnAirlineAddClick(Sender: TObject);
    procedure BtnAirlineEddClick(Sender: TObject);
    procedure BtnAirlineDelClick(Sender: TObject);
    procedure BtnAircraftAddClick(Sender: TObject);
    procedure BtnAircraftDelNowClick(Sender: TObject);
    procedure BtnAircraftDelClick(Sender: TObject);
    procedure BtnAircraftEddClick(Sender: TObject);
    procedure BtnFlightsAddClick(Sender: TObject);
    procedure BtnFlightsEddClick(Sender: TObject);
    procedure BtnFlightsDelNowClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormAED: TFormAED;

implementation

{$R *.dfm}

uses Unit2;


procedure TFormAED.BtnAircraftDelClick(Sender: TObject);   //�������� ����� ������ (�� ������� - �����)
Var buf : string;
begin
  if (DBEditAircraftID.Text = '') then
  begin
    ShowMessage('������� ����� �������� ���������� ��������.');
    exit;
  end;

  //���� ����� �������� � ����
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT FlightsAircraftID AS ID FROM Flights ');
  SQLQuery1.SQL.Add('WHERE FlightsAircraftID = ' + DBEditAircraftID.Text);
  SQLQuery1.Open;
  ClientDataSet1.Active := true;

  Buf := VarToStr(SQLQuery1.FieldValues['ID']);
  if buf <> '' then
    begin
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('DELETE FROM Flights WHERE FlightsAircraftID = ' + DBEditAircraftID.Text);
      SQLQuery1.ExecSQL;
    end;

  //�������
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('DELETE FROM Aircraft WHERE AircraftID = ' + DBEditAircraftID.Text);
  SQLQuery1.ExecSQL;

  ShowMessage('������� ������� ������.');
  FormAir.RefreshSQLClick(Self);
end;

procedure TFormAED.BtnAircraftDelNowClick(Sender: TObject);
Var buf : string;
begin
  if (DBEditAircraftID.Text = '') then
  begin
    ShowMessage('�������� �������.');
    exit;
  end;
  //���� ����� �������� � ����
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT FlightsAircraftID AS ID FROM Flights ');
  SQLQuery1.SQL.Add('WHERE FlightsAircraftID = ' + DBEditAircraftID.Text);
  SQLQuery1.Open;
  ClientDataSet1.Active := true;

  Buf := VarToStr(SQLQuery1.FieldValues['ID']);
  if buf <> '' then
    begin
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('DELETE FROM Flights WHERE FlightsAircraftID = ' + DBEditAircraftID.Text);
      SQLQuery1.ExecSQL;
    end;

  //�������
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('DELETE FROM Aircraft WHERE AircraftID = ' + DBEditAircraftID.Text);
  SQLQuery1.ExecSQL;

  ShowMessage('������� ������� ������� ������.');
  FormAir.RefreshSQLClick(Self);
end;

procedure TFormAED.BtnAircraftEddClick(Sender: TObject);
Var bufAircraftName : string;
begin
  if DBEditAircraftName.Text = '' then
  begin
    ShowMessage('������� ��� ����������� ��������.');
    exit;
  end;
  if DBEditAircraftVelocity.Text = '' then
  begin
    ShowMessage('������� �������� ����������� ��������.');
    exit;
  end;
  if DBEditAircraftEnginesType.Text = '' then
  begin
    ShowMessage('������� ��� ��������� ����������� ��������.');
    exit;
  end;
  if DBEditAircraftAirlineID.Text = '' then
  begin
    ShowMessage('������� ����� �������� ����������� ��������.');
    exit;
  end;
  if DBEditAircraftCapacity.Text = '' then
  begin
    ShowMessage('������� ����������� ����������� ��������.');
    exit;
  end;

  if EditAircraftName.Text = '' then
  begin
    ShowMessage('������� ����� ��� ��������.');
    exit;
  end;
  if EditAircraftVelocity.Text = '' then
  begin
    ShowMessage('������� ����� �������� ��������.');
    exit;
  end;
  if EditAircraftEnginesType.Text = '' then
  begin
    ShowMessage('������� ����� ��� ��������� ��������.');
    exit;
  end;
  if EditAircraftAirlineID.Text = '' then
  begin
    ShowMessage('������� ����� ����� �������� ��������.');
    exit;
  end;
  if EditAircraftCapacity.Text = '' then
  begin
    ShowMessage('������� ����� ����������� ��������.');
    exit;
  end;

  //��������
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('UPDATE Aircraft Set AircraftAirlineID = ' + EditAircraftAirlineID.Text + ', ');
  SQLQuery1.SQL.Add('AircraftName = "' + EditAircraftName.Text + '", AircraftVelocity = "');
  SQLQuery1.SQL.Add(EditAircraftVelocity.Text + '", AircraftEnginesType = "');
  SQLQuery1.SQL.Add(EditAircraftEnginesType.Text + '", AircraftCapacity = ' + EditAircraftCapacity.Text);
  SQLQuery1.SQL.Add(' WHERE AircraftID = ' + DBEditAircraftID.Text);
  SQLQuery1.ExecSQL;

  ShowMessage('������� ������� �������.');

  FormAir.RefreshSQLClick(Self);
end;

//���������� ������������
procedure TFormAED.BtnAirlineAddClick(Sender: TObject);
Var buf, bufNameAirline, BufID : string;
    ID : integer;
begin
  if EditAirline.Text = '' then  //������ �� ������� - �����
    begin
      ShowMessage('������� ����� ������������.');
      exit;
    end;
  //���� ����� �������� � ����
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT AirlineName FROM Airline WHERE AirlineName = "' + EditAirline.Text + '"');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;

  //������� - �����
  bufNameAirline := VarToStr(SQLQuery1.FieldValues['AirlineName']);
  if bufNameAirline = EditAirline.Text then
  begin
    ShowMessage('�������� ��� ����������.');
    exit;
  end;

  //���� ���� ID
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT MAX(AirlineID) AS ID FROM Airline');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;

  //��������� ������
  BufID := IntToStr(SQLQuery1.FieldValues['ID']);
  ID := StrToInt(BufID) + 1;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('INSERT INTO Airline(AirlineID, AirlineName) VALUES (');
  SQLQuery1.SQL.Add(IntToStr(ID) + ', "' + EditAirline.Text + '")');
  SQLQuery1.ExecSQL;

  ShowMessage('�������� ������� ���������.');
  FormAir.RefreshSQLClick(Self);
end;

procedure TFormAED.BtnAirlineDelClick(Sender: TObject);
Var bufNameAirline, bufAirlineID, BufID, BufAircraftID, i: string;
begin
  if (EditAirline.Text = '') then
  begin
    ShowMessage('������� ��������� ��������.');
    exit;
  end;

  //���� ����� �������� � ����
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT AirlineName FROM Airline WHERE AirlineName = "' + EditAirline.Text + '"');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;

  //�� ������� - �����
  bufNameAirline := VarToStr(SQLQuery1.FieldValues['AirlineName']);
  if bufNameAirline <> EditAirline.Text then
  begin
    ShowMessage('�������� �� ����������.');
    exit;
  end;

  //���� ����� �������� ����
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT AirlineID AS ID FROM Airline WHERE AirlineName = "' + EditAirline.Text + '"');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;
  bufAirlineID := VarToStr(SQLQuery1.FieldValues['ID']); //��������� ����� ��������

  repeat
  BufAircraftID := '';

  //���� �������� � ���� �� ������ ��������
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT AircraftID AS ID FROM Aircraft ');
  SQLQuery1.SQL.Add('WHERE AircraftAirlineID = ' + bufAirlineID);
  SQLQuery1.Open;
  ClientDataSet1.Active := true;
  BufAircraftID := VarToStr(SQLQuery1.FieldValues['ID']); //��������� ����� ��������

  //��������� ��� - �����
  if BufAircraftID = '' then
    exit;

  //������� ��� ����� ��������
  BufID := VarToStr(SQLQuery1.FieldValues['ID']);
  if bufID <> '' then
    begin
      SQLQuery1.Close;
      SQLQuery1.SQL.Clear;
      SQLQuery1.SQL.Add('DELETE FROM Flights WHERE FlightsAircraftID = ' + BufAircraftID);
      SQLQuery1.ExecSQL;
    end;

  //������� ������� ��������
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('DELETE FROM Aircraft WHERE AircraftID = ' + BufAircraftID);
  SQLQuery1.ExecSQL;
  until BufAircraftID = ''; //���� �� ���������� ��� ��������

  //������� ��������
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('DELETE FROM Airline WHERE AirlineName = "' + EditAirline.Text + '"');
  SQLQuery1.ExecSQL;

  ShowMessage('�������� ������� �������.');
  FormAir.RefreshSQLClick(Self);
end;

procedure TFormAED.BtnAirlineEddClick(Sender: TObject);
Var bufNameAirline : string;
begin
  if (EditAirline.Text = '') then
  begin
    ShowMessage('������� ����� ��������.');
    exit;
  end;

  //���� ����� �������� � ����
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT AirlineName FROM Airline WHERE AirlineName = "' + EditAirline.Text + '"');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;

  //������� - �����
  bufNameAirline := VarToStr(SQLQuery1.FieldValues['AirlineName']);
  if bufNameAirline = EditAirline.Text then
  begin
    ShowMessage('�������� ��� ����������.');
    exit;
  end;

  //��������
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('UPDATE Airline Set AirlineName = "' + EditAirline.Text + '" ');
  SQLQuery1.SQL.Add('WHERE AirlineName = "' + DBEditAirline.Text + '"');
  SQLQuery1.ExecSQL;

  ShowMessage('�������� ������� ��������.');
  FormAir.RefreshSQLClick(Self);
end;

procedure TFormAED.BtnFlightsAddClick(Sender: TObject);
Var buf, bufNameAircraft, BufID, bufStatusID : string;
    ID : integer;
    MyDate1, MyDate2: TDateTime;
begin
  if EditFlightsAircraftID.Text = '' then
  begin
    ShowMessage('������� ����� ��������.');
    exit;
  end;
  if EditFlightsDeparturePoint.Text = '' then
  begin
    ShowMessage('������� ����� ������ ��������.');
    exit;
  end;
  if EditFlightsArrivalPoint.Text = '' then
  begin
    ShowMessage('������� ����� ������� ��������.');
    exit;
  end;
  if DBLookupComboBoxFlightsStatusID.Text = '' then
  begin
    ShowMessage('�������� ������ ��������.');
    exit;
  end;

  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT MAX(FlightsID) AS ID FROM Flights');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;
  BufID := IntToStr(SQLQuery1.FieldValues['ID']);
  ID := StrToInt(BufID) + 1;

  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT StatusID AS ID FROM Status WHERE StatusName = "' + DBLookupComboBoxFlightsStatusID.Text + '"');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;
  bufStatusID := VarToStr(SQLQuery1.FieldValues['ID']);

  MyDate1 := StrToDateTime(EditFlightsDepartureTime.Text);
  MyDate2 := StrToDateTime(EditFlightsArrivalTime.Text);
  //��������� ������
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('INSERT INTO Flights(FlightsID, FlightsAircraftID, FlightsDepartureTime, ');
  SQLQuery1.SQL.Add('FlightsArrivalTime, FlightsDeparturePoint, FlightsArrivalPoint, FlightsStatusID) VALUES (');
  SQLQuery1.SQL.Add(IntToStr(ID) + ', ' + EditFlightsAircraftID.Text + ', "');
  SQLQuery1.SQL.Add(FormatDateTime('yyyy-mm-dd hh:mm:ss', MyDate1) + '", "');
  SQLQuery1.SQL.Add(FormatDateTime('yyyy-mm-dd hh:mm:ss', MyDate2));
  SQLQuery1.SQL.Add('", "' + EditFlightsDeparturePoint.Text + '", "');
  SQLQuery1.SQL.Add(EditFlightsArrivalPoint.Text + '", ' + bufStatusID + ')');
  SQLQuery1.ExecSQL;

  ShowMessage('���� ������� ��������.');
  FormAir.RefreshSQLClick(Self);
end;

procedure TFormAED.BtnFlightsDelNowClick(Sender: TObject);
begin
  if DBEditFlightsID.Text = '' then
  begin
    ShowMessage('������� ����� ���������� �����.');
    exit;
  end;

  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('DELETE FROM Flights WHERE FlightsID = ' + DBEditFlightsID.Text);
  SQLQuery1.ExecSQL;

  ShowMessage('���� ������� ������.');
  FormAir.RefreshSQLClick(Self);
end;

procedure TFormAED.BtnFlightsEddClick(Sender: TObject);
Var MyDate1, MyDate2: TDateTime;
    bufStatusID : string;
begin
  if EditFlightsAircraftID.Text = '' then
  begin
    ShowMessage('������� ����� ����� ��������.');
    exit;
  end;
  if EditFlightsDeparturePoint.Text = '' then
  begin
    ShowMessage('������� ����� ����� ������ ��������.');
    exit;
  end;
  if EditFlightsArrivalPoint.Text = '' then
  begin
    ShowMessage('������� ����� ����� ������� ��������.');
    exit;
  end;
  if DBLookupComboBoxFlightsStatusID.Text = '' then
  begin
    ShowMessage('�������� ����� ������ ��������.');
    exit;
  end;

  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT StatusID AS ID FROM Status WHERE StatusName = "' + DBLookupComboBoxFlightsStatusID.Text + '"');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;
  bufStatusID := VarToStr(SQLQuery1.FieldValues['ID']);

  MyDate1 := StrToDateTime(EditFlightsDepartureTime.Text);
  MyDate2 := StrToDateTime(EditFlightsArrivalTime.Text);

  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('UPDATE Flights Set FlightsAircraftID = ' + EditFlightsAircraftID.Text + ', ');
  SQLQuery1.SQL.Add('FlightsDepartureTime = "' + FormatDateTime('yyyy-mm-dd hh:mm:ss', MyDate1));
  SQLQuery1.SQL.Add('", FlightsArrivalTime = "' + FormatDateTime('yyyy-mm-dd hh:mm:ss', MyDate2));
  SQLQuery1.SQL.Add(EditAircraftVelocity.Text + '", FlightsDeparturePoint = "');
  SQLQuery1.SQL.Add(EditFlightsDeparturePoint.Text + '", FlightsArrivalPoint = ' + EditFlightsArrivalPoint.Text);
  SQLQuery1.SQL.Add(', FlightsStatusID = ' + bufStatusID);
  SQLQuery1.SQL.Add(' WHERE FlightsID = ' + DBEditFlightsID.Text);
  SQLQuery1.ExecSQL;

  ShowMessage('���� ������� �������.');

  FormAir.RefreshSQLClick(Self);
end;

procedure TFormAED.BtnAircraftAddClick(Sender: TObject);
Var buf, bufNameAircraft, BufID : string;
    ID : integer;
begin
  if EditAircraftName.Text = '' then
  begin
    ShowMessage('������� ��� ������ ��������.');
    exit;
  end;
  if EditAircraftVelocity.Text = '' then
  begin
    ShowMessage('������� �������� ������ ��������.');
    exit;
  end;
  if EditAircraftEnginesType.Text = '' then
  begin
    ShowMessage('������� ��� ��������� ������ ��������.');
    exit;
  end;
  if EditAircraftAirlineID.Text = '' then
  begin
    ShowMessage('������� ����� �������� ������ ��������.');
    exit;
  end;
  if EditAircraftCapacity.Text = '' then
  begin
    ShowMessage('������� ����������� ������ ��������.');
    exit;
  end;

  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT MAX(AircraftID) AS ID FROM Aircraft');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;

  BufID := IntToStr(SQLQuery1.FieldValues['ID']);
  ID := StrToInt(BufID) + 1;

  //��������� ������
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('INSERT INTO Aircraft(AircraftID, AircraftAirlineID, AircraftName, ');
  SQLQuery1.SQL.Add('AircraftVelocity, AircraftEnginesType, AircraftCapacity) VALUES (');
  SQLQuery1.SQL.Add(IntToStr(ID) + ', ' + EditAircraftAirlineID.Text + ', "' + EditAircraftName.Text + '", "');
  SQLQuery1.SQL.Add(EditAircraftVelocity.Text + '", "' + EditAircraftEnginesType.Text + '", ');
  SQLQuery1.SQL.Add(EditAircraftCapacity.Text + ')');
  SQLQuery1.ExecSQL;

  ShowMessage('������� ������� ��������.');
  FormAir.RefreshSQLClick(Self);
end;

end.
