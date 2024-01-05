using Magic.Modules;
using Magic.Provider;
using Magic.Relayer;

namespace Magic
{
    public sealed class Magic
    {
        // static instance
        public static Magic Instance;
        public readonly AuthModule Auth;

        public readonly RpcProvider Provider;
        public readonly UserModule User;

        //Constructor
        public Magic(string apikey, EthNetwork network = EthNetwork.Mainnet, string locale = "en-US")
        {
            var urlBuilder = new UrlBuilder(apikey, network, locale);
            UrlBuilder.Instance = urlBuilder;
            
            Provider = new RpcProvider(urlBuilder);
            User = new UserModule(Provider);
            Auth = new AuthModule(Provider);
        }

        public Magic(string apikey, CustomNodeConfiguration config, string locale = "en-US")
        {
            var urlBuilder = new UrlBuilder(apikey, config, locale);
            UrlBuilder.Instance = urlBuilder;

            Provider = new RpcProvider(urlBuilder);
            User = new UserModule(Provider);
            Auth = new AuthModule(Provider);
        }
    }

    public enum EthNetwork
    {
        Mainnet,
        Goerli,
    }
}
