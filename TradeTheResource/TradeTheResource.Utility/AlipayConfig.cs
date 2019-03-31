using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeTheResource.Utility
{
    public class AlipayConfig
    {
        //appid
        public static string app_id = "2016091400505906";

        //支付宝网关
        public static string gatewayUrl = "https://openapi.alipaydev.com/gateway.do";

        //商户私钥 
        public static string private_key = "MIIEpAIBAAKCAQEAwgG9HoB9srCuUi67J2tRILQ6p0zTQ6TmwhQk0b/6S/fApUX86Xrefb4yISjwoi9de7n2ygPWCe7FU+WwovJXNXvm13K0ayaVMnYLUdMj2Xo8yza1zBS59zD1ffEfleuAACkWFw7Bv83kLObMAtoNnO8+dEFgvMP5PkC/7jS6W1jEQsc9FTa2oWEzw+eN+UsfFc3idMc1YVG3T1qQDieiH6abMthEDKtXrdoRnIzmf6IRxr4Xnh7QzBhrntOSC95wX+wCa3yFCZWVGA0Gxl+N109w0wODDL1agFfbs2p6O9PZ2oIGWqdRf0HEAe0QNUVOwNXhXataBTU11mxG/cbVkQIDAQABAoIBABR7aIL638pous60Xk/oFZWVUYfuJXPDyhT9WXHHid5RVsZcIDpqHWk7FkHH97e3tm/kjzh+tS8xRSX5Xu+lFC3yWcmvM3sIhMHiEond96/zJs3xhbn5CjUdtx1HwqTqSwY5UDq49R2R2CAhcbJvYPaLj5VofZUQP5Uh8uFsMayJAFv1Ji6vue41NY4Ukwpv0A/wUuZylIEIV6K7NCxDIZ291STkpnM3jGQg+VzzHs7MdmAmdL+nZ8FkDeqmG3Nrd/LjYtqTHaaU1OQ49nR13z/waKEqWi4DlDf6avwo06o5zFLaFc6xUYwdBBeb8Vag09pNrEU4ubVehoZxHhZiwj0CgYEA8vQt872XEW/UVst2t7uz/I8GDMSXHoTsZYAQruVNubeW8XueZwx2qihG3CBRU26cjeqqMfK7dxtnTdXXlrqMzG+wiiqI0GcxhCfOdyqcGFLjwaR95QM7omghrDk9pLYG7OBohdyqPHJZzehTxaZgmMOMZ63WlPmUuhJbpr7YcLcCgYEAzGyylsnYO1cZgd3oRFnTkt3KD4bqYkfGMlt8YzIgeHNUVp/1/k4p9mLILJI6xPtd5o1GXki0XT/smauuBRpgpgjAKOQfBhTi/oK7JoOXN+IKzGPgQOVLBnBlI6csbv6yrDQjBf6rHosXPToewCie1oHWRkLnkW1x8SE0wUSPk/cCgYEAvLcCwqNvprGwxEKC0rDQW8tUrbI+mAwz+5uAWfnvZ+S9MJIPNogt3HowoGfSA/aVUH8I+IdNKnV0xrbmIUSCfYH8JTZo00h04+xvqYzFdvdbxlxZFfxu4/Xywe4sfbaOpoyhY+lFqnJAY3qlJ4/W1JKAi0Ayv8Elz2rXGix/vv0CgYAaVrb77q3Jl4NV1D2k8N3twl3SelOgrha/TkJMlZzRaCqprpqHVZLaiAe6lmy0DJ8goXs7kqqKiT323sPhLHDfc6kum5XTtsU4faeXYsUNEjbJ9uRh+Ckef0TIvzVeZ7qlrWIF17Y8jTdFUEO+Bn3QrZHqI5yqhCt2Ig0mCatmKQKBgQDgDm/LRVaCiDqZ+fSNW2kQwNac66NxhoRx6X8BvISortnjTRVsMT3HseFPAnWRPA2PjumJoB4TOe6qMrK/r5/OsJ58F+6fpwolosiUgF0F+9wRGtzY6uqZlAzxynX5/tGn39Bk0zBXhC1XiXhiyg4D4KICNEQWl1kAih1E5lxmWw==";

        //支付宝公钥
        public static string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtQCGtFU+BwXD8E1QhZKlMmHhfiRtnZVoxQDzdWTFetHy6PZTdpmLM6MseI0dqBjiQFtEa2F7Pe6TXTQj+G+R1DdztlG6INKiAr2KjNXwNdmXCYWbhJ+8i6bnzcNLbGFLsnZScRdwR7LhDIRi2OA9CDr9ePYyvQIAcgSVL4ePjzRg33rZMMHQLpH3HkPaYGqFREOVN5IPcgc0miBLD8e8FkX/0WFA8W3WLImO0NU92FsQvPi2JNd0DfKcBFRJxHGu0sjH/F9YkL+0O3Dhr1vqrku7ZqZUiYY4oixBPYW3sJRci7dfmJjwcSaLzZJN6PDvZtdWMQbdcjc4mvKrYWzLlQIDAQAB";

        //签名方式
        public static string sign_type = "RSA2";

        //编码格式
        public static string charset = "UTF-8";

        //支付完成跳转地址
        // public static string notifyUrl = "http://www.lilysunshine.top/home/notifyUrl";

    }
}
