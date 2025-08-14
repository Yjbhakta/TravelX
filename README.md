# Travel-X.com - The Future of Travel Booking

A revolutionary travel platform designed to replace traditional OTAs like Expedia, Booking.com, Airbnb, and VRBO. Travel-X is co-owned by hotel owners, investors, and founders, creating a fairer ecosystem for everyone.

## 🚀 Project Overview

Travel-X eliminates OTA commissions (15-30%) by connecting travelers directly with hotels while providing co-ownership opportunities for all stakeholders.

### Key Features

- **Zero Commission**: Hotels keep 100% of their revenue
- **Co-Ownership**: Platform tokens for hotel owners and investors
- **Direct Booking**: Travelers get better prices and authentic experiences
- **Blockchain Transparency**: Real ownership and governance rights

## 🏗️ Technology Stack

### Frontend
- **Blazor WebAssembly** (.NET 9)
- **Tailwind CSS 4.1** for styling
- **MudBlazor** for rich UI components
- **Responsive Design** for all devices

### Backend
- **ASP.NET Core 9** API
- **Entity Framework Core** with SQL Server
- **MediatR** for CQRS pattern
- **AutoMapper** for object mapping

## 📁 Project Structure

```
Travel-X/
├── src/
│   ├── TravelX.Web/          # Blazor WebAssembly Frontend
│   ├── TravelX.Api/          # ASP.NET Core API Backend
│   └── TravelX.Shared/       # Shared models and utilities
├── tests/
│   └── TravelX.Tests/        # Unit tests
├── docs/                     # Documentation
└── scripts/                  # Build and deployment scripts
```

## 🎯 User Types

### 1. Travelers
- Better prices (15-30% savings)
- Direct communication with hotels
- Exclusive perks and upgrades
- Travel-X token rewards

### 2. Hotel Owners
- Zero commission fees
- Direct guest relationships
- Platform co-ownership tokens
- Advanced analytics and tools

### 3. Investors
- Own a piece of the $2.8T travel market
- Revenue sharing through dividends
- Governance voting rights
- Multiple investment tiers

### 4. Admins
- User management and approvals
- Content management
- Analytics dashboard
- Communication tools

## 🛠️ Getting Started

### Prerequisites
- .NET 9 SDK
- SQL Server or SQL Server Express
- Node.js (for Tailwind CSS)

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone [repository-url]
   cd Travel-X
   ```

2. **Install dependencies**
   ```bash
   npm install
   dotnet restore
   ```

3. **Setup database**
   ```bash
   dotnet ef database update -p src/TravelX.Api
   ```

4. **Build and run**
   ```bash
   # Terminal 1: Start API
   cd src/TravelX.Api
   dotnet run

   # Terminal 2: Start Blazor
   cd src/TravelX.Web
   dotnet run
   ```

5. **Build CSS (optional)**
   ```bash
   npm run build-css
   ```

## 🌐 Environment Configuration

### Development
- API: https://localhost:5001
- Frontend: https://localhost:5000

### Production
Configure appsettings.json with your production settings:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your production SQL Server connection"
  },
  "Jwt": {
    "Key": "your-secret-key",
    "Issuer": "travel-x.com"
  }
}
```

## 📊 Marketing Features

### X-Tra Marketing Campaigns
Based on the provided Requirements.md, the platform includes:

- **X-Tra Ordinary**: Unique travel experiences
- **X-Tra Value**: Superior pricing and deals
- **X-Tra Ease**: Hassle-free booking
- **X-Tra Loyalty**: Rewards program
- **X-Tra Expansion**: Global growth

### Advanced Features
- **X-Tra Adventure**: Adventure packages
- **X-Tra Luxe**: Luxury offerings
- **X-Tra Green**: Eco-friendly options
- **X-Tra Local**: Cultural immersion
- **X-Tra Family**: Family-friendly options

## 🔐 Security Features

- JWT authentication
- Role-based authorization
- Email verification
- Secure password hashing
- GDPR compliance

## 📈 Investment Opportunities

### Investment Tiers
- **Founder**: $25,000 - 25,000 tokens + 0.1% ownership
- **Partner**: $100,000 - 125,000 tokens + 0.5% ownership
- **Visionary**: $500,000 - 750,000 tokens + 2.5% ownership

### Token Economics
- Total Supply: 100 Million TX tokens
- Revenue sharing through quarterly dividends
- Governance voting rights
- Tradeable on exchanges

## 🚀 Deployment

### Azure Deployment
1. Create Azure Web App
2. Configure SQL Database
3. Setup CDN for static assets
4. Configure custom domain
5. Setup SSL certificates

### Docker Support
```bash
# Build images
docker build -t travelx-api ./src/TravelX.Api
docker build -t travelx-web ./src/TravelX.Web

# Run containers
docker-compose up
```

## 📞 Support

- **Email**: hello@travel-x.com
- **Documentation**: docs.travel-x.com
- **Support**: support.travel-x.com
- **Community**: community.travel-x.com

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## 📄 License

This project is proprietary software owned by Travel-X stakeholders. All rights reserved.

## 🎯 Roadmap

### Q1 2024
- [x] Marketing website launch
- [x] User registration system
- [x] Hotel owner onboarding
- [x] Investor portal

### Q2 2024
- [ ] Payment integration
- [ ] Booking system
- [ ] Token launch
- [ ] Mobile app development

### Q3 2024
- [ ] Global expansion
- [ ] AI recommendations
- [ ] Blockchain integration
- [ ] Partnership program

### Q4 2024
- [ ] Series A funding
- [ ] IPO preparation
- [ ] Advanced analytics
- [ ] VR/AR features