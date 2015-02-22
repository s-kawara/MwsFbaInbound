using FBAInboundServiceMWS;
using FBAInboundServiceMWS.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace MwsFbaInbound
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create InboundShipment plan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateinboundShipmentPlan_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAInboundServiceMWSConfig config = new FBAInboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAInboundServiceMWSClient client = new FBAInboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            CreateInboundShipmentPlanRequest request = new CreateInboundShipmentPlanRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;
            Address shipFromAddress = new Address();
            shipFromAddress.AddressLine1 = txtAddress1.Text;
            shipFromAddress.AddressLine2 = txtAddress2.Text;
            shipFromAddress.City = txtCity.Text;
            shipFromAddress.StateOrProvinceCode = txtPrefecture.Text;
            shipFromAddress.Name = txtName.Text;
            shipFromAddress.PostalCode = txtPostalCode.Text;
            shipFromAddress.CountryCode = "JP";
            request.ShipFromAddress = shipFromAddress;
            request.LabelPrepPreference = "SELLER_LABEL";
            request.ShipToCountryCode = "JP";
            InboundShipmentPlanRequestItemList itemList = new InboundShipmentPlanRequestItemList();
            InboundShipmentPlanRequestItem item = new InboundShipmentPlanRequestItem();
            item.SellerSKU = txtSKU.Text;
            item.Quantity = 1;
            itemList.member.Add(item);
            request.WithInboundShipmentPlanRequestItems(itemList);
            CreateInboundShipmentPlanResponse response = client.CreateInboundShipmentPlan(request);
            if (response.IsSetCreateInboundShipmentPlanResult())
            {
                CreateInboundShipmentPlanResult createInboundShipmentPlanResult = response.CreateInboundShipmentPlanResult;
                if (createInboundShipmentPlanResult.IsSetInboundShipmentPlans())
                {
                    InboundShipmentPlanList inboundShipmentPlans = createInboundShipmentPlanResult.InboundShipmentPlans;
                    List<InboundShipmentPlan> memberList = inboundShipmentPlans.member;
                    foreach (InboundShipmentPlan member in memberList)
                    {
                        if (member.IsSetShipmentId())
                        {
                            strbuff = "シップメントID：" + member.ShipmentId;
                        }
                    }
                }
            }
            txtCreateinboundShipmentPlan.Text = strbuff;
        }

        /// <summary>
        /// Create Inbound Shipment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateInboundShipment_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAInboundServiceMWSConfig config = new FBAInboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAInboundServiceMWSClient client = new FBAInboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            CreateInboundShipmentPlanRequest request = new CreateInboundShipmentPlanRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;
            Address shipFromAddress = new Address();
            shipFromAddress.AddressLine1 = txtAddress11.Text;
            shipFromAddress.AddressLine2 = txtAddress21.Text;
            shipFromAddress.City = txtCity1.Text;
            shipFromAddress.StateOrProvinceCode = txtPrefecture1.Text;
            shipFromAddress.Name = txtName1.Text;
            shipFromAddress.PostalCode = txtPostalCode1.Text;
            shipFromAddress.CountryCode = "JP";
            request.ShipFromAddress = shipFromAddress;
            request.LabelPrepPreference = "SELLER_LABEL";
            request.ShipToCountryCode = "JP";
            InboundShipmentPlanRequestItemList itemList = new InboundShipmentPlanRequestItemList();
            InboundShipmentPlanRequestItem item = new InboundShipmentPlanRequestItem();
            item.SellerSKU = txtSKU1.Text;
            item.Quantity = 1;
            itemList.member.Add(item);
            request.WithInboundShipmentPlanRequestItems(itemList);
            CreateInboundShipmentPlanResponse response = client.CreateInboundShipmentPlan(request);
            if (response.IsSetCreateInboundShipmentPlanResult())
            {
                CreateInboundShipmentPlanResult createInboundShipmentPlanResult = response.CreateInboundShipmentPlanResult;
                if (createInboundShipmentPlanResult.IsSetInboundShipmentPlans())
                {
                    InboundShipmentPlanList inboundShipmentPlans = createInboundShipmentPlanResult.InboundShipmentPlans;
                    List<InboundShipmentPlan> memberList = inboundShipmentPlans.member;
                    foreach (InboundShipmentPlan member in memberList)
                    {
                        if (member.IsSetShipmentId())
                        {
                            CreateInboundShipmentRequest request1 = new CreateInboundShipmentRequest();

                            request1.SellerId = SellerId;
                            request1.Marketplace = MarketplaceId;
                            request1.MWSAuthToken = MWSAuthToken;
                            request1.ShipmentId = member.ShipmentId;

                            InboundShipmentHeader inboundShipmentHeader = new InboundShipmentHeader();
                            inboundShipmentHeader.ShipFromAddress = shipFromAddress;
                            inboundShipmentHeader.LabelPrepPreference = "SELLER_LABEL";
                            inboundShipmentHeader.ShipmentName = txtSKU1.Text;
                            request1.InboundShipmentHeader = inboundShipmentHeader;
                            InboundShipmentItemList itemList1 = new InboundShipmentItemList();
                            InboundShipmentItem item1 = new InboundShipmentItem();
                            item1.SellerSKU = txtSKU1.Text;
                            item1.QuantityShipped = 1;
                            itemList1.member.Add(item1);
                            request1.WithInboundShipmentItems(itemList1);
                            request1.InboundShipmentHeader.DestinationFulfillmentCenterId = member.DestinationFulfillmentCenterId;
                            CreateInboundShipmentResponse response1 = client.CreateInboundShipment(request1);
                            if (response1.IsSetCreateInboundShipmentResult())
                            {
                                strbuff = "処理が正常に完了しました。";
                            }
                            else
                            {
                                strbuff = "処理時にエラーが発生しました。";
                            }
                        }
                    }
                }
            }
            txtCreateInboundShipment.Text = strbuff;
        }

        /// <summary>
        /// Update InboundShipment 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateInboundShipment_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAInboundServiceMWSConfig config = new FBAInboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAInboundServiceMWSClient client = new FBAInboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            UpdateInboundShipmentRequest request = new UpdateInboundShipmentRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;
            request.ShipmentId = txtShipId2.Text;

            InboundShipmentItemList itemList = new InboundShipmentItemList();
            InboundShipmentItem item = new InboundShipmentItem();
            item.SellerSKU = txtSKU2.Text;
            item.QuantityShipped = decimal.Parse(txtQuantity2.Text);

            itemList.member.Add(item);
            request.WithInboundShipmentItems(itemList);
            UpdateInboundShipmentResponse response = client.UpdateInboundShipment(request);
            if (response.IsSetUpdateInboundShipmentResult())
            {
                strbuff = "正常に処理が完了しました。";
            }
            else
            {
                strbuff = "処理途中でエラーが発生しました。";
            }
            txtUpdateInboundShipment.Text = strbuff;
        }

        /// <summary>
        /// Get Inbound Shipments List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListInboundShipments_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAInboundServiceMWSConfig config = new FBAInboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAInboundServiceMWSClient client = new FBAInboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            ListInboundShipmentsRequest request = new ListInboundShipmentsRequest();
            request.SellerId = SellerId;
            request.MWSAuthToken = MWSAuthToken;
            request.Marketplace = MarketplaceId;
            ShipmentStatusList list = new ShipmentStatusList();
            list.member.Add("WORKING");
            request.ShipmentStatusList = list;
            ListInboundShipmentsResponse response = client.ListInboundShipments(request);
            if (response.IsSetListInboundShipmentsResult())
            {
                ListInboundShipmentsResult listInboundShipmentsResult = response.ListInboundShipmentsResult;
                if (listInboundShipmentsResult.IsSetShipmentData())
                {
                    InboundShipmentList shipmentData = listInboundShipmentsResult.ShipmentData;
                    List<InboundShipmentInfo> memberList = shipmentData.member;
                    foreach (InboundShipmentInfo member in memberList)
                    {
                        strbuff = "シップメント名：" + member.ShipmentName;
                    }
                }
            }
            txtListInboundShipments.Text = strbuff;
        }

        /// <summary>
        /// Get Next Inbound Shipment Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListInboundShipmentsByNextToken_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAInboundServiceMWSConfig config = new FBAInboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAInboundServiceMWSClient client = new FBAInboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            ListInboundShipmentsRequest request = new ListInboundShipmentsRequest();
            request.SellerId = SellerId;
            request.MWSAuthToken = MWSAuthToken;
            request.Marketplace = MarketplaceId;
            ShipmentStatusList list = new ShipmentStatusList();
            list.member.Add("WORKING");
            request.ShipmentStatusList = list;
            ListInboundShipmentsResponse response = client.ListInboundShipments(request);
            if (response.IsSetListInboundShipmentsResult())
            {
                if (response.ListInboundShipmentsResult.NextToken != null)
                {
                    ListInboundShipmentsByNextTokenRequest request1 = new ListInboundShipmentsByNextTokenRequest();
                    request1.SellerId = SellerId;
                    request1.Marketplace = MarketplaceId;
                    request1.NextToken = response.ListInboundShipmentsResult.NextToken;
                    ListInboundShipmentsByNextTokenResponse response1 = client.ListInboundShipmentsByNextToken(request1);
                    if (response1.IsSetListInboundShipmentsByNextTokenResult())
                    {
                        ListInboundShipmentsByNextTokenResult listInboundShipmentsResult = response1.ListInboundShipmentsByNextTokenResult;
                        if (listInboundShipmentsResult.IsSetShipmentData())
                        {
                            InboundShipmentList shipmentData = listInboundShipmentsResult.ShipmentData;
                            List<InboundShipmentInfo> memberList = shipmentData.member;
                            foreach (InboundShipmentInfo member in memberList)
                            {
                                // データ取得・表示
                                strbuff += "シップメント名：" + member.ShipmentName;
                            }
                        }
                    }
                }
                else
                {
                    strbuff = "次の情報がありません。";
                }
            }
            txtListInboundShipmentsByNextToken.Text = strbuff;
        }

        /// <summary>
        /// Get Inbound Shipment Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListInboundShipmentItems_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAInboundServiceMWSConfig config = new FBAInboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAInboundServiceMWSClient client = new FBAInboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            ListInboundShipmentItemsRequest request = new ListInboundShipmentItemsRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;
            request.ShipmentId = "Set ShipmentId";
            ListInboundShipmentItemsResponse response = client.ListInboundShipmentItems(request);
            if (response.IsSetListInboundShipmentItemsResult())
            {
                ListInboundShipmentItemsResult listInboundShipmentItemsResult = response.ListInboundShipmentItemsResult;
                InboundShipmentItemList itemData = listInboundShipmentItemsResult.ItemData;
                foreach (InboundShipmentItem item in itemData.member)
                {
                    strbuff += "SKU番号:" + item.SellerSKU + System.Environment.NewLine;
                }
            }
            txtListInboundShipmentItems.Text = strbuff;
        }

        /// <summary>
        /// Get Next Inbound Shipment Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListInboundShipmentItemsByNextToken_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAInboundServiceMWSConfig config = new FBAInboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAInboundServiceMWSClient client = new FBAInboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            ListInboundShipmentItemsRequest request = new ListInboundShipmentItemsRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;
            request.ShipmentId = "Set ShipmentId";
            ListInboundShipmentItemsResponse response = client.ListInboundShipmentItems(request);
            if (response.IsSetListInboundShipmentItemsResult())
            {
                if (response.ListInboundShipmentItemsResult.NextToken != null)
                {
                    ListInboundShipmentItemsByNextTokenRequest request1 = new ListInboundShipmentItemsByNextTokenRequest();
                    request1.SellerId = SellerId;
                    request1.Marketplace = MarketplaceId;
                    request1.NextToken = response.ListInboundShipmentItemsResult.NextToken;
                    // データ取得処理
                    ListInboundShipmentItemsByNextTokenResponse response1 = client.ListInboundShipmentItemsByNextToken(request1);
                    if (response1.IsSetListInboundShipmentItemsByNextTokenResult())
                    {
                        ListInboundShipmentItemsByNextTokenResult listInboundShipmentItemsByNextTokenResult = response1.ListInboundShipmentItemsByNextTokenResult;
                        if (listInboundShipmentItemsByNextTokenResult.IsSetItemData())
                        {
                            InboundShipmentItemList itemData = listInboundShipmentItemsByNextTokenResult.ItemData;
                            foreach (InboundShipmentItem item in itemData.member)
                            {
                                strbuff += "SKU番号:" + item.SellerSKU + System.Environment.NewLine;
                            }
                        }
                    }
                }
                else
                {
                    strbuff = "次のアイテムがありません。";
                }
            }
            txtListInboundShipmentItemsByNextToken.Text = strbuff;

        }

        /// <summary>
        /// FbaInbountShipment Service Check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetServiceStatus_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAInboundServiceMWSConfig config = new FBAInboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAInboundServiceMWSClient client = new FBAInboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            GetServiceStatusRequest request = new GetServiceStatusRequest();
            request.SellerId = SellerId;
            request.MWSAuthToken = MWSAuthToken;
            request.Marketplace = MarketplaceId;
            GetServiceStatusResponse response = client.GetServiceStatus(request);
            if (response.IsSetGetServiceStatusResult())
            {
                strbuff = "正常終了：" + response.GetServiceStatusResult.Status;
            }
            else
            {
                strbuff = "異常終了：" + response.GetServiceStatusResult.Status;
            }
            txtGetServiceStatus.Text = strbuff;
        }
    }
}
